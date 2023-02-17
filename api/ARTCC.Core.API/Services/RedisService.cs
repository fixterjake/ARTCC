using ARTCC.Core.API.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Security.Claims;

namespace ARTCC.Core.API.Services;

public class RedisService
{
    private readonly DatabaseContext _context;
    private readonly IDatabase _redis;
    private readonly ILogger<RedisService> _logger;

    public RedisService(DatabaseContext context, IDatabase redis, ILogger<RedisService> logger)
    {
        _context = context;
        _redis = redis;
        _logger = logger;
    }

    public async Task<IList<string>?> GetPermissions(ClaimsPrincipal user)
    {
        var cidRaw = user.Claims.FirstOrDefault(x => x.Type == "cid");
        if (cidRaw == null || !int.TryParse(cidRaw.Value, out var cid))
        {
            _logger.LogInformation("[RedisService] Cid was null or an invalid int: {Cid}", cidRaw?.Value);
            return null;
        }

        var permissionsRaw = await _redis.StringGetAsync($"permissions-{cid}");
        if (permissionsRaw.IsNull)
        {
            var dbUser = await _context.Users
                .Include(x => x.Roles)
                .ThenInclude(x => x.Permissions)
                .FirstOrDefaultAsync(x => x.Id == cid);
            if (dbUser == null)
                return new List<string>();

            _logger.LogInformation("[RedisService] Permissions not in redis, adding to redis and returning Permissions");

            var permissions = new List<string>();
            foreach (var entry in dbUser.Roles)
                permissions.AddRange(entry.Permissions.Select(x => x.Value));

            await SetPermissions(permissions, dbUser.Id);
            return permissions;
        }

        _logger.LogInformation("[RedisService] Roles in redis, returning them");

        return JsonConvert.DeserializeObject<IList<string>>(permissionsRaw!);
    }

    public async Task SetPermissions(IList<string> permissions, int userId)
    {
        await _redis.StringSetAsync($"permissions-{userId}", JsonConvert.SerializeObject(permissions), TimeSpan.FromMinutes(15));
    }

    public async Task<bool> ValidatePermissions(ClaimsPrincipal user, string[] permissions)
    {
        var userPermissions = await GetPermissions(user);
        if (userPermissions == null)
            return false;
        foreach (var entry in userPermissions)
            if (permissions.Any(x => x == entry))
                return true;
        return false;
    }
}

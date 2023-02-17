using ARTCC.Core.API.Data;
using ARTCC.Core.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VATSIM.Connect.AspNetCore.Server.Services;
using VATSIM.Connect.AspNetCore.Shared.DTO;

namespace ARTCC.Core.API.Services;

public class AuthenticationService : IVatsimAuthenticationService
{

    private readonly DatabaseContext _context;
    private readonly RedisService _redisService;

    public AuthenticationService(DatabaseContext context, RedisService redisService)
    {
        _context = context;
        _redisService = redisService;
    }

    public async Task<IEnumerable<Claim>> ProcessVatsimUserLogin(VatsimUserDto user)
    {
        var claims = new List<Claim>();
        var u = await _context.Users
            .Include(x => x.Roles)
            .ThenInclude(x => x.Permissions)
            .FirstOrDefaultAsync(x => x.Id == user.Cid);

        claims.Add(new Claim("RatingInt", $"{user.VatsimDetails.ControllerRating.Id}"));

        if (u == null || u.Status == UserStatus.REMOVED)
        {
            claims.Add(new Claim("IsMember", $"{false}"));
            claims.Add(new Claim("roles", string.Empty));
            return claims;
        }

        claims.Add(new Claim("IsMember", $"{true}"));

        if (u.Roles == null)
        {
            claims.Add(new Claim("roles", string.Empty));
            return claims;
        }

        var permissions = new List<string>();
        foreach (var entry in u.Roles)
            permissions.AddRange(entry.Permissions.Select(x => x.Value));

        claims.AddRange(permissions
            .Select(x =>
                new Claim("roles", x)
            ));

        await _redisService.SetPermissions(permissions, u.Id);

        return claims;
    }
}


using System.Text.Json.Serialization;

namespace ARTCC.Core.Shared.Models;

public class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string NameShort { get; set; }
    public required string Email { get; set; }
    public bool IsStaff { get; set; }
    public int Priority { get; set; }

    [JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public required ICollection<Permission> Permissions { get; set; }

    [JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public required ICollection<User> Users { get; set; }
}

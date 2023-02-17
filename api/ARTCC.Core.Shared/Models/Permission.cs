using System.Text.Json.Serialization;

namespace ARTCC.Core.Shared.Models;

public class Permission
{
    public int Id { get; set; }
    public required string Value { get; set; }

    [JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public required ICollection<Role> Roles { get; set; }
}

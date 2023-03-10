using ARTCC.Core.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace ARTCC.Core.Shared.Models;

[Index(nameof(FirstName))]
[Index(nameof(LastName))]
[Index(nameof(Email))]
[Index(nameof(Rating))]
[Index(nameof(Status))]
public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public Rating Rating { get; set; }
    public DateTimeOffset Joined { get; set; }
    public UserStatus Status { get; set; } = UserStatus.ACTIVE;
    public required ICollection<Role> Roles { get; set; }
    public DateTimeOffset Created { get; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
}
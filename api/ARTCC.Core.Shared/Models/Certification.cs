using ARTCC.Core.Shared.Enums;

namespace ARTCC.Core.Shared.Models;

public class Certification
{
    public int Id { get; set; }
    public int Order { get; set; }
    public required string Name { get; set; }
    public Rating RequiredRating { get; set; }
    public DateTimeOffset Created { get; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;
}

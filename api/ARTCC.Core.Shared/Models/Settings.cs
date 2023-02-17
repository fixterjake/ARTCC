namespace ARTCC.Core.Shared.Models;

public class Settings
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? IconUrl { get; set; }
    public string? LogoUrl { get; set; }
    public string? BannerUrl { get; set; }
    public bool SetupDone { get; set; }
    public bool VisitingOpen { get; set; }
    public int RequiredHours { get; set; }
    public DateTimeOffset LastUpdated { get; set; } = DateTimeOffset.UtcNow;
}

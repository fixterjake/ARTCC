using ARTCC.Core.Shared.Models;
using ARTCC.Core.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace ARTCC.Core.API.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public required DbSet<Airport> Airports { get; set; }
    public required DbSet<Certification> Certifications { get; set; }
    public required DbSet<Comment> Comments { get; set; }
    public required DbSet<EmailLog> EmailLogs { get; set; }
    public required DbSet<Event> Events { get; set; }
    public required DbSet<EventPosition> EventPositions { get; set; }
    public required DbSet<EventRegistration> EventRegistrations { get; set; }
    public required DbSet<Faq> Faq { get; set; }
    public required DbSet<Feedback> Feedback { get; set; }
    public required DbSet<Shared.Models.File> Files { get; set; }
    public required DbSet<News> News { get; set; }
    public required DbSet<OnlineController> OnlineControllers { get; set; }
    public required DbSet<Ots> Ots { get; set; }
    public required DbSet<Permission> Permissions { get; set; }
    public required DbSet<Role> Roles { get; set; }
    public required DbSet<Session> Sessions { get; set; }
    public required DbSet<Settings> Settings { get; set; }
    public required DbSet<TrainingRequest> TrainingRequests { get; set; }
    public required DbSet<TrainingTicket> TrainingTickets { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<UserCertification> UserCertifications { get; set; }
    public required DbSet<VisitingApplication> VisitingApplications { get; set; }
    public required DbSet<WebsiteLog> WebsiteLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 1, Roles = new List<Role>(), Value = Constants.PERMISSION_CREATE_AIRPORT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 2, Roles = new List<Role>(), Value = Constants.PERMISSION_UPDATE_AIRPORT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 3, Roles = new List<Role>(), Value = Constants.PERMISSION_DELETE_AIRPORT });

        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 4, Roles = new List<Role>(), Value = Constants.PERMISSION_CREATE_COMMENT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 5, Roles = new List<Role>(), Value = Constants.PERMISSION_READ_COMMENT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 6, Roles = new List<Role>(), Value = Constants.PERMISSION_READ_CONFIDENTIAL_COMMENT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 7, Roles = new List<Role>(), Value = Constants.PERMISSION_DELETE_COMMENT });

        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 8, Roles = new List<Role>(), Value = Constants.PERMISSION_CREATE_EVENT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 9, Roles = new List<Role>(), Value = Constants.PERMISSION_VIEW_CLOSED_EVENTS });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 10, Roles = new List<Role>(), Value = Constants.PERMISSION_UPDATE_EVENT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 11, Roles = new List<Role>(), Value = Constants.PERMISSION_DELETE_EVENT });

        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 12, Roles = new List<Role>(), Value = Constants.PERMISSION_CREATE_EVENT_POSITION });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 13, Roles = new List<Role>(), Value = Constants.PERMISSION_DELETE_EVENT_POSITION });

        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 14, Roles = new List<Role>(), Value = Constants.PERMISSION_CREATE_EVENT_REGISTRATION });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 15, Roles = new List<Role>(), Value = Constants.PERMISSION_VIEW_EVENT_REGISTRATIONS });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 16, Roles = new List<Role>(), Value = Constants.PERMISSION_ASSIGN_EVENT_REGISTRATIONS });

        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 17, Roles = new List<Role>(), Value = Constants.PERMISSION_CREATE_FAQ });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 18, Roles = new List<Role>(), Value = Constants.PERMISSION_UPDATE_FAQ });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 19, Roles = new List<Role>(), Value = Constants.PERMISSION_DELETE_FAQ });

        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 20, Roles = new List<Role>(), Value = Constants.PERMISSION_VIEW_TRAINING_MANAGEMENT });
        modelBuilder.Entity<Permission>().HasData(new Permission { Id = 21, Roles = new List<Role>(), Value = Constants.PERMISSION_VIEW_ARTCC_MANAGEMENT });

        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 1,
            Name = "Air Traffic Manager",
            NameShort = "ATM",
            Email = "atm@test.com",
            IsStaff = true,
            Priority = 1,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 2,
            Name = "Deputy Air Traffic Manager",
            NameShort = "DATM",
            Email = "datm@test.com",
            IsStaff = true,
            Priority = 2,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 3,
            Name = "Training Administrator",
            NameShort = "TA",
            Email = "ta@test.com",
            IsStaff = true,
            Priority = 3,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 4,
            Name = "Assistant Training Administrator",
            NameShort = "ATA",
            Email = "ata@test.com",
            IsStaff = true,
            Priority = 4,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 5,
            Name = "Webmaster",
            NameShort = "WM",
            Email = "wm@test.com",
            IsStaff = true,
            Priority = 5,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 6,
            Name = "Assistant Webmaster",
            NameShort = "AWM",
            Email = "awm@test.com",
            IsStaff = true,
            Priority = 6,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 7,
            Name = "Events Coordinator",
            NameShort = "EC",
            Email = "ec@test.com",
            IsStaff = true,
            Priority = 7,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 8,
            Name = "Assistant Events Coordinator",
            NameShort = "AEC",
            Email = "aec@test.com",
            IsStaff = true,
            Priority = 8,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 9,
            Name = "Facility Engineer",
            NameShort = "FE",
            Email = "fe@test.com",
            IsStaff = true,
            Priority = 9,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 10,
            Name = "Assistant Facility Engineer",
            NameShort = "AFE",
            Email = "afe@test.com",
            IsStaff = true,
            Priority = 10,
            Permissions = new List<Permission>(),
            Users = new List<User>()
        });
    }
}
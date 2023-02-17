﻿// <auto-generated />
using System;
using ARTCC.Core.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ARTCC.Core.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230111041930_VariousUpdates")]
    partial class VariousUpdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Altimeter")
                        .HasColumnType("text");

                    b.Property<int>("Arrivals")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Departures")
                        .HasColumnType("integer");

                    b.Property<string>("Icao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MetarRaw")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Temperature")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Wind")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RequiredRating")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Confidential")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubmitterId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubmitterId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.EmailLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmailLogs");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UploadId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UploadId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.EventPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Assigned")
                        .HasColumnType("boolean");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<int>("MinRating")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventPositions");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.EventRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EventRegistrations");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Faq");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserCallsign")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UploadId")
                        .HasColumnType("integer");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UploadId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EditorId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Created");

                    b.HasIndex("EditorId");

                    b.HasIndex("Title");

                    b.HasIndex("Updated");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.OnlineController", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Callsign")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OnlineControllers");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsStaff")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameShort")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Callsign")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Callsign");

                    b.HasIndex("End");

                    b.HasIndex("Frequency");

                    b.HasIndex("Name");

                    b.HasIndex("Start");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BannerId")
                        .HasColumnType("integer");

                    b.Property<int>("IconId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LogoId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RequiredHours")
                        .HasColumnType("integer");

                    b.Property<bool>("VisitingOpen")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("BannerId");

                    b.HasIndex("IconId");

                    b.HasIndex("LogoId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Upload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Uploads");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Joined")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.HasIndex("Rating");

                    b.HasIndex("Status");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.UserCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CertificationId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCertifications");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.VisitingApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cid")
                        .HasColumnType("integer");

                    b.Property<string>("DenialReason")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("VisitingApplications");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.WebsiteLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cid")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NewData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OldData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WebsiteLogs");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("integer");

                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.HasKey("PermissionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PermissionRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Comment", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.User", "Submitter")
                        .WithMany()
                        .HasForeignKey("SubmitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTCC.Core.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submitter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Event", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Upload", "Upload")
                        .WithMany()
                        .HasForeignKey("UploadId");

                    b.Navigation("Upload");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.EventPosition", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.EventRegistration", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Feedback", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.File", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Upload", "Upload")
                        .WithMany()
                        .HasForeignKey("UploadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Upload");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.News", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.User", "Editor")
                        .WithMany()
                        .HasForeignKey("EditorId");

                    b.HasOne("ARTCC.Core.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Session", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.Settings", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Upload", "Banner")
                        .WithMany()
                        .HasForeignKey("BannerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTCC.Core.Shared.Models.Upload", "Icon")
                        .WithMany()
                        .HasForeignKey("IconId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTCC.Core.Shared.Models.Upload", "Logo")
                        .WithMany()
                        .HasForeignKey("LogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banner");

                    b.Navigation("Icon");

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("ARTCC.Core.Shared.Models.UserCertification", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Certification", "Certification")
                        .WithMany()
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTCC.Core.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTCC.Core.Shared.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("ARTCC.Core.Shared.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTCC.Core.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

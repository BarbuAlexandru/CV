﻿// <auto-generated />
using System;
using LiveShow.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiveShow.Dal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200523205250_Update1")]
    partial class Update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiveShow.Dal.Models.Attendance", b =>
                {
                    b.Property<Guid>("ShowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttendeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ShowId", "AttendeeId");

                    b.HasIndex("AttendeeId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Following", b =>
                {
                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FolloweeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FollowerId", "FolloweeId");

                    b.HasIndex("FolloweeId");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OriginalDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalVenue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Show", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.UserNotification", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "NotificationId");

                    b.HasIndex("NotificationId");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Attendance", b =>
                {
                    b.HasOne("LiveShow.Dal.Models.User", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveShow.Dal.Models.Show", "Show")
                        .WithMany("Attendances")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Following", b =>
                {
                    b.HasOne("LiveShow.Dal.Models.User", "Followee")
                        .WithMany("Followers")
                        .HasForeignKey("FolloweeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LiveShow.Dal.Models.User", "Follower")
                        .WithMany("Followees")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Notification", b =>
                {
                    b.HasOne("LiveShow.Dal.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LiveShow.Dal.Models.Show", b =>
                {
                    b.HasOne("LiveShow.Dal.Models.User", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("LiveShow.Dal.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LiveShow.Dal.Models.UserNotification", b =>
                {
                    b.HasOne("LiveShow.Dal.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveShow.Dal.Models.User", "User")
                        .WithMany("UserNotifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

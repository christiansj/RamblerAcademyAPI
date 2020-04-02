﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RamblerAcademyAPI.Data;

namespace RamblerAcademyAPI.Migrations
{
    [DbContext(typeof(RamblerAcademyContext))]
    [Migration("20200402212549_EnrollmentModel")]
    partial class EnrollmentModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RamblerAcademyAPI.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Building");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Main Building"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Johnson Arts"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Welch Sciences"
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<int>("HallwayNumber")
                        .HasColumnType("integer");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("Floor", "HallwayNumber", "RoomNumber", "BuildingId")
                        .IsUnique();

                    b.ToTable("Classroom");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildingId = 1,
                            Floor = 1,
                            HallwayNumber = 1,
                            RoomNumber = 12
                        },
                        new
                        {
                            Id = 2,
                            BuildingId = 1,
                            Floor = 1,
                            HallwayNumber = 1,
                            RoomNumber = 14
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = "MAT010",
                            Name = "College Algebra"
                        },
                        new
                        {
                            Id = "MAT100",
                            Name = "Pre-Calculus"
                        },
                        new
                        {
                            Id = "MAT400",
                            Name = "Calculus I"
                        },
                        new
                        {
                            Id = "MAT250",
                            Name = "Summer Math Camp"
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.CourseSection", b =>
                {
                    b.Property<int>("CourseReferenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClassroomId")
                        .HasColumnType("integer");

                    b.Property<string>("CourseId")
                        .HasColumnType("text");

                    b.Property<DateTime>("FinalExamDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SectionNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SemesterId")
                        .HasColumnType("integer");

                    b.HasKey("CourseReferenceNumber");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("CourseId", "SectionNumber", "SemesterId")
                        .IsUnique();

                    b.ToTable("CourseSection");

                    b.HasData(
                        new
                        {
                            CourseReferenceNumber = 57494,
                            ClassroomId = 1,
                            CourseId = "MAT010",
                            FinalExamDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SectionNumber = 1,
                            SemesterId = 1
                        },
                        new
                        {
                            CourseReferenceNumber = 59256,
                            ClassroomId = 2,
                            CourseId = "MAT100",
                            FinalExamDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SectionNumber = 1,
                            SemesterId = 1
                        },
                        new
                        {
                            CourseReferenceNumber = 28539,
                            ClassroomId = 1,
                            CourseId = "MAT250",
                            FinalExamDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SectionNumber = 1,
                            SemesterId = 2
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.CourseSectionTimeSlot", b =>
                {
                    b.Property<int>("CourseReferenceNumber")
                        .HasColumnType("integer");

                    b.Property<int>("DayId")
                        .HasColumnType("integer");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("integer");

                    b.HasKey("CourseReferenceNumber", "DayId", "TimeSlotId");

                    b.HasIndex("DayId", "TimeSlotId");

                    b.ToTable("CourseSectionTimeSlots");

                    b.HasData(
                        new
                        {
                            CourseReferenceNumber = 57494,
                            DayId = 1,
                            TimeSlotId = 2
                        },
                        new
                        {
                            CourseReferenceNumber = 57494,
                            DayId = 3,
                            TimeSlotId = 2
                        },
                        new
                        {
                            CourseReferenceNumber = 59256,
                            DayId = 2,
                            TimeSlotId = 1
                        },
                        new
                        {
                            CourseReferenceNumber = 59256,
                            DayId = 4,
                            TimeSlotId = 1
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sunday"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monday"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tuesday"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wednesday"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Thursday"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Friday"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Saturday"
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.DayTimeSlot", b =>
                {
                    b.Property<int>("DayId")
                        .HasColumnType("integer");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("integer");

                    b.HasKey("DayId", "TimeSlotId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("DayTimeSlot");

                    b.HasData(
                        new
                        {
                            DayId = 1,
                            TimeSlotId = 2
                        },
                        new
                        {
                            DayId = 3,
                            TimeSlotId = 2
                        },
                        new
                        {
                            DayId = 2,
                            TimeSlotId = 1
                        },
                        new
                        {
                            DayId = 4,
                            TimeSlotId = 1
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Enrollment", b =>
                {
                    b.Property<int>("CourseReferenceNumber")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("CourseReferenceNumber", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Normal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Super Admin"
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Season");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Spring"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Summer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fall"
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SeasonId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Semester");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2010, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = 1,
                            StartDate = new DateTime(2010, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2010
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2010, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = 2,
                            StartDate = new DateTime(2010, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2010
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2010, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SeasonId = 3,
                            StartDate = new DateTime(2010, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2010
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.TimeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("StartTime", "EndTime")
                        .IsUnique();

                    b.ToTable("TimeSlot");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new TimeSpan(0, 8, 45, 0, 0),
                            StartTime = new TimeSpan(0, 7, 30, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new TimeSpan(0, 12, 45, 0, 0),
                            StartTime = new TimeSpan(0, 11, 30, 0, 0)
                        });
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Classroom", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.CourseSection", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RamblerAcademyAPI.Models.Course", "Course")
                        .WithMany("CourseSections")
                        .HasForeignKey("CourseId");

                    b.HasOne("RamblerAcademyAPI.Models.Semester", "Semester")
                        .WithMany("CourseSections")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.CourseSectionTimeSlot", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.CourseSection", "CourseSection")
                        .WithMany()
                        .HasForeignKey("CourseReferenceNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RamblerAcademyAPI.Models.DayTimeSlot", "DayTimeSlot")
                        .WithMany("CourseSectionTimeSlots")
                        .HasForeignKey("DayId", "TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.DayTimeSlot", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.Day", "Day")
                        .WithMany()
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RamblerAcademyAPI.Models.TimeSlot", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Enrollment", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.CourseSection", "CourseSection")
                        .WithMany()
                        .HasForeignKey("CourseReferenceNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RamblerAcademyAPI.Models.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.Semester", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.Season", "Season")
                        .WithMany("Semesters")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.User", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

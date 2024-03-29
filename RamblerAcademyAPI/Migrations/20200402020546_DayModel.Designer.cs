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
    [Migration("20200402020546_DayModel")]
    partial class DayModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

            modelBuilder.Entity("RamblerAcademyAPI.Models.CourseSemester", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("text");

                    b.Property<int>("SemesterId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId", "SemesterId");

                    b.HasIndex("SemesterId");

                    b.ToTable("CourseSemester");

                    b.HasData(
                        new
                        {
                            CourseId = "MAT010",
                            SemesterId = 1
                        },
                        new
                        {
                            CourseId = "MAT100",
                            SemesterId = 1
                        },
                        new
                        {
                            CourseId = "MAT400",
                            SemesterId = 1
                        },
                        new
                        {
                            CourseId = "MAT250",
                            SemesterId = 2
                        },
                        new
                        {
                            CourseId = "MAT010",
                            SemesterId = 3
                        },
                        new
                        {
                            CourseId = "MAT100",
                            SemesterId = 3
                        },
                        new
                        {
                            CourseId = "MAT400",
                            SemesterId = 3
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

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("RamblerAcademyAPI.Models.CourseSemester", b =>
                {
                    b.HasOne("RamblerAcademyAPI.Models.Course", "Course")
                        .WithMany("CourseSemsters")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RamblerAcademyAPI.Models.Semester", "Semester")
                        .WithMany("CourseSemesters")
                        .HasForeignKey("SemesterId")
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
#pragma warning restore 612, 618
        }
    }
}

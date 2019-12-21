﻿// <auto-generated />
using System;
using Lab_34_GymWebsite_MVC_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab_34_GymWebsite_MVC_Core.Migrations
{
    [DbContext(typeof(GymDatabaseModel))]
    [Migration("20191220111840_WorkoutLog")]
    partial class WorkoutLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab_34_GymWebsite_MVC_Core.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Lab_34_GymWebsite_MVC_Core.Exercis", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("ExerciseName")
                        .HasMaxLength(50);

                    b.HasKey("ExerciseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Lab_34_GymWebsite_MVC_Core.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateJoined");

                    b.Property<bool?>("InductionCompleted");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lab_34_GymWebsite_MVC_Core.WorkoutLog", b =>
                {
                    b.Property<int>("WorkoutLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateTime");

                    b.Property<int>("ExerciseId");

                    b.HasKey("WorkoutLogId");

                    b.ToTable("WorkoutLogs");
                });

            modelBuilder.Entity("Lab_34_GymWebsite_MVC_Core.Exercis", b =>
                {
                    b.HasOne("Lab_34_GymWebsite_MVC_Core.Category", "Category")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

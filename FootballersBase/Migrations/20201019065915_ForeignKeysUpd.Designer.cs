﻿// <auto-generated />
using System;
using FootballersBase.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballersBase.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201019065915_ForeignKeysUpd")]
    partial class ForeignKeysUpd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballersBase.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachId");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("Town");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("FootballersBase.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClubId");

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("NationalTeamId");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("NationalTeamId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("FootballersBase.Models.NationalTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachId");

                    b.Property<string>("Country");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("NationalTeams");
                });

            modelBuilder.Entity("FootballersBase.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int?>("ClubId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("NationalTeamId");

                    b.Property<string>("Nationality");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("NationalTeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootballersBase.Models.Club", b =>
                {
                    b.HasOne("FootballersBase.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");
                });

            modelBuilder.Entity("FootballersBase.Models.Coach", b =>
                {
                    b.HasOne("FootballersBase.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");

                    b.HasOne("FootballersBase.Models.NationalTeam", "NationalTeam")
                        .WithMany()
                        .HasForeignKey("NationalTeamId");
                });

            modelBuilder.Entity("FootballersBase.Models.NationalTeam", b =>
                {
                    b.HasOne("FootballersBase.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");
                });

            modelBuilder.Entity("FootballersBase.Models.Player", b =>
                {
                    b.HasOne("FootballersBase.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");

                    b.HasOne("FootballersBase.Models.NationalTeam", "NationalTeam")
                        .WithMany()
                        .HasForeignKey("NationalTeamId");
                });
#pragma warning restore 612, 618
        }
    }
}

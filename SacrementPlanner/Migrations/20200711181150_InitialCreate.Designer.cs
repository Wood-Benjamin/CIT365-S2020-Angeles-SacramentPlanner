﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacrementPlanner.Data;

namespace SacrementPlanner.Migrations
{
    [DbContext(typeof(SacrementPlannerContext))]
    [Migration("20200711181150_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacrementPlanner.Models.Meeting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Benediction");

                    b.Property<string>("ClosingHymn");

                    b.Property<string>("Conducting");

                    b.Property<string>("IntermediateHymn");

                    b.Property<string>("Invocation");

                    b.Property<DateTime>("MeetingDate");

                    b.Property<string>("OpeningHymn");

                    b.Property<string>("Presiding");

                    b.Property<string>("SacamentHymn");

                    b.Property<string>("SpecialNotes");

                    b.HasKey("ID");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("SacrementPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SpeakerName");

                    b.Property<string>("Topic");

                    b.HasKey("ID");

                    b.ToTable("Speaker");
                });
#pragma warning restore 612, 618
        }
    }
}
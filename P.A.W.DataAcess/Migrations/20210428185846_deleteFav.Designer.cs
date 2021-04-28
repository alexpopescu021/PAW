﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAW.DataAcess;

namespace PAWDataAcess.Migrations
{
    [DbContext(typeof(PAWDbContext))]
    [Migration("20210428185846_deleteFav")]
    partial class deleteFav
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PAW.Model.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SongId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("PAW.Model.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("PAW.Model.Quiz", b =>
                {
                    b.HasOne("PAW.Model.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId");
                });
#pragma warning restore 612, 618
        }
    }
}

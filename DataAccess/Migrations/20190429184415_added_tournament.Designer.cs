﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190429184415_added_tournament")]
    partial class added_tournament
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview4.19216.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Sport", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("DataAccess.TableClasses.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("SportId")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataAccess.TableClasses.Tournament", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32);

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("DataAccess.TableClasses.Category", b =>
                {
                    b.HasOne("DataAccess.Sport", "Sport")
                        .WithMany("Categories")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.TableClasses.Tournament", b =>
                {
                    b.HasOne("DataAccess.TableClasses.Category", "Category")
                        .WithMany("Tournaments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

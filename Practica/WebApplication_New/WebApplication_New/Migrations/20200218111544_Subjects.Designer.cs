﻿// <auto-generated />
using System;
using Academy.Lib.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication_New.Migrations
{
    [DbContext(typeof(AcademyDbContext))]
    [Migration("20200218111544_Subjects")]
    partial class Subjects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Common.Lib.Core.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity");
                });

            modelBuilder.Entity("Academy.Lib.Models.Student", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<int>("ChairNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dni")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Academy.Lib.Models.Subject", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<string>("Name")
                        .HasColumnName("Subject_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Teacher")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}

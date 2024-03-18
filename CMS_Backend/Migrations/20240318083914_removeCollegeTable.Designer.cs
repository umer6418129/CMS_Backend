﻿// <auto-generated />
using System;
using CMS_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMS_Backend.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240318083914_removeCollegeTable")]
    partial class removeCollegeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMS_Backend.Models.College", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("CMS_Backend.Models.CollegeFaciliteis", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("collegeId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CollegeFaciliteis");
                });

            modelBuilder.Entity("CMS_Backend.Models.ContactUs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("CMS_Backend.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("course_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentFeedback", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("std_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("std_id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("addmission_status")
                        .HasColumnType("int");

                    b.Property<int?>("course_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("std_date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("std_father_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("std_mother_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("std_permanent_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("std_residential_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("std_unique_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("course_id");

                    b.HasIndex("user_id");

                    b.ToTable("StudentInfos");
                });

            modelBuilder.Entity("CMS_Backend.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("role_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CMS_Backend.Models.UserRoles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentFeedback", b =>
                {
                    b.HasOne("CMS_Backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("std_id");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentInfo", b =>
                {
                    b.HasOne("CMS_Backend.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("course_id");

                    b.HasOne("CMS_Backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("course");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CMS_Backend.Models.User", b =>
                {
                    b.HasOne("CMS_Backend.Models.UserRoles", "user_roles")
                        .WithMany()
                        .HasForeignKey("role_id");

                    b.Navigation("user_roles");
                });
#pragma warning restore 612, 618
        }
    }
}

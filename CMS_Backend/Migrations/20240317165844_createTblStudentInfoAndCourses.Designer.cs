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
    [Migration("20240317165844_createTblStudentInfoAndCourses")]
    partial class createTblStudentInfoAndCourses
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

                    b.Property<int?>("collegeId")
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

                    b.HasIndex("collegeId");

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

                    b.Property<int?>("collegeId")
                        .HasColumnType("int");

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

                    b.HasIndex("collegeId");

                    b.HasIndex("role_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CMS_Backend.Models.UserRoles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CollegeId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CollegeId");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentInfo", b =>
                {
                    b.HasOne("CMS_Backend.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("collegeId");

                    b.HasOne("CMS_Backend.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("course_id");

                    b.HasOne("CMS_Backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("College");

                    b.Navigation("course");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CMS_Backend.Models.User", b =>
                {
                    b.HasOne("CMS_Backend.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("collegeId");

                    b.HasOne("CMS_Backend.Models.UserRoles", "user_roles")
                        .WithMany()
                        .HasForeignKey("role_id");

                    b.Navigation("College");

                    b.Navigation("user_roles");
                });

            modelBuilder.Entity("CMS_Backend.Models.UserRoles", b =>
                {
                    b.HasOne("CMS_Backend.Models.College", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId");

                    b.Navigation("College");
                });
#pragma warning restore 612, 618
        }
    }
}
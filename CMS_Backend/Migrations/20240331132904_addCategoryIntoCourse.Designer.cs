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
    [Migration("20240331132904_addCategoryIntoCourse")]
    partial class addCategoryIntoCourse
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

                    b.Property<int?>("category_id")
                        .HasColumnType("int");

                    b.Property<string>("course_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("is_available")
                        .HasColumnType("bit");

                    b.Property<bool?>("is_featured")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("category_id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CMS_Backend.Models.CourseCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CourseCategories");
                });

            modelBuilder.Entity("CMS_Backend.Models.CourseSubjects", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<int>("subject_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("course_id");

                    b.HasIndex("subject_id");

                    b.ToTable("CourseSubjects");
                });

            modelBuilder.Entity("CMS_Backend.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CMS_Backend.Models.Facilities", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("CMS_Backend.Models.FacultyInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("department_id")
                        .HasColumnType("int");

                    b.Property<int?>("faculty_type_id")
                        .HasColumnType("int");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("department_id");

                    b.HasIndex("faculty_type_id");

                    b.HasIndex("user_id");

                    b.ToTable("FacultyInfos");
                });

            modelBuilder.Entity("CMS_Backend.Models.FacultyType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FacultyTypes");
                });

            modelBuilder.Entity("CMS_Backend.Models.FileRepo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("file_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("rowId")
                        .HasColumnType("int");

                    b.Property<string>("tbl_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FileRepos");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentFeedback", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<int?>("courseId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("std_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("courseId");

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

            modelBuilder.Entity("CMS_Backend.Models.Subjects", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Subjects");
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

                    b.Property<bool?>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("password")
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

            modelBuilder.Entity("CMS_Backend.Models.Course", b =>
                {
                    b.HasOne("CMS_Backend.Models.CourseCategory", "CourseCategory")
                        .WithMany()
                        .HasForeignKey("category_id");

                    b.Navigation("CourseCategory");
                });

            modelBuilder.Entity("CMS_Backend.Models.CourseSubjects", b =>
                {
                    b.HasOne("CMS_Backend.Models.Course", "course")
                        .WithMany("CourseSubjects")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS_Backend.Models.Subjects", "subjects")
                        .WithMany()
                        .HasForeignKey("subject_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("subjects");
                });

            modelBuilder.Entity("CMS_Backend.Models.FacultyInfo", b =>
                {
                    b.HasOne("CMS_Backend.Models.Department", "department")
                        .WithMany()
                        .HasForeignKey("department_id");

                    b.HasOne("CMS_Backend.Models.FacultyType", "facultyType")
                        .WithMany()
                        .HasForeignKey("faculty_type_id");

                    b.HasOne("CMS_Backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("department");

                    b.Navigation("facultyType");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CMS_Backend.Models.StudentFeedback", b =>
                {
                    b.HasOne("CMS_Backend.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseId");

                    b.HasOne("CMS_Backend.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("std_id");

                    b.Navigation("course");

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

            modelBuilder.Entity("CMS_Backend.Models.Course", b =>
                {
                    b.Navigation("CourseSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
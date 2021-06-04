﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UdemyAPI.Models;

namespace UdemyAPI.Migrations
{
    [DbContext(typeof(UdemyContext))]
    [Migration("20210601194004_dropCardForFixes1")]
    partial class dropCardForFixes1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UdemyAPI.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Admin_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("UdemyAPI.Models.AdminCr", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Admin_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrsId")
                        .HasColumnType("int")
                        .HasColumnName("Crs_Id");

                    b.Property<string>("Manage")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminId", "CrsId");

                    b.ToTable("Admin_Crs");
                });

            modelBuilder.Entity("UdemyAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Category_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category_Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("UdemyAPI.Models.Choice", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Question_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choices")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("QuestionId", "Choices");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("UdemyAPI.Models.Course", b =>
                {
                    b.Property<int>("CrsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Crs_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Duration")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Languge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Levels")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int?>("ShoppingCardCardId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<int>("TopId")
                        .HasColumnType("int")
                        .HasColumnName("Top_Id");

                    b.HasKey("CrsId");

                    b.HasIndex("ShoppingCardCardId");

                    b.HasIndex("TopId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("UdemyAPI.Models.Exam", b =>
                {
                    b.Property<int>("ExmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Exm_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrsId")
                        .HasColumnType("int")
                        .HasColumnName("Crs_Id");

                    b.Property<string>("ExamName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Exam_Name");

                    b.HasKey("ExmId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("UdemyAPI.Models.InstCr", b =>
                {
                    b.Property<int>("InstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Inst_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrsId")
                        .HasColumnType("int")
                        .HasColumnName("Crs_Id");

                    b.HasKey("InstId", "CrsId");

                    b.ToTable("Inst_Crs");
                });

            modelBuilder.Entity("UdemyAPI.Models.Instructor", b =>
                {
                    b.Property<int>("InstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Inst_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Biography")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Communication")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HeadLine")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagPath")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Language")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("UdemyAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Question_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<string>("Formula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("type");

                    b.HasKey("QuestionId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("UdemyAPI.Models.ShoppingCard", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InstId")
                        .HasColumnType("int");

                    b.Property<int?>("StdId")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("InstId")
                        .IsUnique()
                        .HasFilter("[InstId] IS NOT NULL");

                    b.HasIndex("StdId")
                        .IsUnique()
                        .HasFilter("[StdId] IS NOT NULL");

                    b.ToTable("ShoppingCard");
                });

            modelBuilder.Entity("UdemyAPI.Models.StdCr", b =>
                {
                    b.Property<int>("StdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Std_Id");

                    b.Property<int>("CrsId")
                        .HasColumnType("int")
                        .HasColumnName("Crs_Id");

                    b.Property<string>("Certificate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("StdId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("Std_Crs");
                });

            modelBuilder.Entity("UdemyAPI.Models.StdExam", b =>
                {
                    b.Property<int>("StdId")
                        .HasColumnType("int")
                        .HasColumnName("Std_Id");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("Question_Id");

                    b.Property<int>("ExamId")
                        .HasColumnType("int")
                        .HasColumnName("Exam_Id");

                    b.Property<string>("StdAnswer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Std_Answer");

                    b.HasKey("StdId", "QuestionId", "ExamId")
                        .HasName("PK_Std_Exam_1");

                    b.ToTable("Std_Exam");
                });

            modelBuilder.Entity("UdemyAPI.Models.Student", b =>
                {
                    b.Property<int>("StdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Std_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("imagePath");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone");

                    b.HasKey("StdId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("UdemyAPI.Models.SupCateg", b =>
                {
                    b.Property<int>("SupCatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SupCatTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupCatId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SupCategs");
                });

            modelBuilder.Entity("UdemyAPI.Models.Topic", b =>
                {
                    b.Property<int>("TopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Top_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SupCatId")
                        .HasColumnType("int")
                        .HasColumnName("SupCat_Id");

                    b.Property<string>("TopName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Top_Name");

                    b.HasKey("TopId");

                    b.HasIndex("SupCatId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("UdemyAPI.Models.Video", b =>
                {
                    b.Property<int>("VidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Vid_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrsId")
                        .HasColumnType("int")
                        .HasColumnName("Crs_Id");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VidId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("UdemyAPI.Models.Course", b =>
                {
                    b.HasOne("UdemyAPI.Models.ShoppingCard", "ShoppingCard")
                        .WithMany("Courses")
                        .HasForeignKey("ShoppingCardCardId");

                    b.HasOne("UdemyAPI.Models.Topic", "Top")
                        .WithMany("Courses")
                        .HasForeignKey("TopId")
                        .HasConstraintName("FK_Course_Topic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCard");

                    b.Navigation("Top");
                });

            modelBuilder.Entity("UdemyAPI.Models.ShoppingCard", b =>
                {
                    b.HasOne("UdemyAPI.Models.Instructor", "Instructor")
                        .WithOne("ShoppingCard")
                        .HasForeignKey("UdemyAPI.Models.ShoppingCard", "InstId");

                    b.HasOne("UdemyAPI.Models.Student", "Student")
                        .WithOne("ShoppingCard")
                        .HasForeignKey("UdemyAPI.Models.ShoppingCard", "StdId");

                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UdemyAPI.Models.StdCr", b =>
                {
                    b.HasOne("UdemyAPI.Models.Course", "Course")
                        .WithMany("studentCourses")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UdemyAPI.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UdemyAPI.Models.SupCateg", b =>
                {
                    b.HasOne("UdemyAPI.Models.Category", "Category")
                        .WithMany("SupCategs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UdemyAPI.Models.Topic", b =>
                {
                    b.HasOne("UdemyAPI.Models.SupCateg", "supCateg")
                        .WithMany("Topics")
                        .HasForeignKey("SupCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("supCateg");
                });

            modelBuilder.Entity("UdemyAPI.Models.Category", b =>
                {
                    b.Navigation("SupCategs");
                });

            modelBuilder.Entity("UdemyAPI.Models.Course", b =>
                {
                    b.Navigation("studentCourses");
                });

            modelBuilder.Entity("UdemyAPI.Models.Instructor", b =>
                {
                    b.Navigation("ShoppingCard");
                });

            modelBuilder.Entity("UdemyAPI.Models.ShoppingCard", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("UdemyAPI.Models.Student", b =>
                {
                    b.Navigation("ShoppingCard");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("UdemyAPI.Models.SupCateg", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("UdemyAPI.Models.Topic", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UdemyAPI.Services;
#nullable disable

namespace UdemyAPI.Models
{
    public partial class UdemyContext : DbContext
    {
        public UdemyContext()
        {
        }

        public UdemyContext(DbContextOptions<UdemyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminCr> AdminCrs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<InstCr> InstCrs { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StdCr> StdCrs { get; set; }
        public virtual DbSet<StdExam> StdExams { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Udemy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.Img).HasMaxLength(50);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AdminCr>(entity =>
            {
                entity.HasKey(e => new { e.AdminId, e.CrsId });

                entity.ToTable("Admin_Crs");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Admin_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.Manage).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Category_Name");
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.Choices });

                entity.ToTable("Choice");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Question_Id");

                entity.Property(e => e.Choices).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CrsId);

                entity.ToTable("Course");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.CrsName)
                    .HasMaxLength(50)
                    .HasColumnName("Crs_name");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.TopId).HasColumnName("Top_Id");

                entity.HasOne(d => d.Top)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TopId)
                    .HasConstraintName("FK_Course_Topic");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.ExmId);

                entity.ToTable("Exam");

                entity.Property(e => e.ExmId).HasColumnName("Exm_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.ExamName)
                    .HasMaxLength(50)
                    .HasColumnName("Exam_Name");
            });

            modelBuilder.Entity<InstCr>(entity =>
            {
                entity.HasKey(e => new { e.InstId, e.CrsId });

                entity.ToTable("Inst_Crs");

                entity.Property(e => e.InstId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Inst_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InstId);

                entity.ToTable("Instructor");

                entity.Property(e => e.InstId).HasColumnName("Inst_Id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.ImagPath).HasMaxLength(50);

                entity.Property(e => e.InstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Inst_Name");

                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("Question_Id");

                entity.Property(e => e.Answer).HasMaxLength(50);

                entity.Property(e => e.Formula)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<StdCr>(entity =>
            {
                entity.HasKey(e => new { e.StdId, e.CrsId });

                entity.ToTable("Std_Crs");

                entity.Property(e => e.StdId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Std_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.Certificate).HasMaxLength(50);
            });

            modelBuilder.Entity<StdExam>(entity =>
            {
                entity.HasKey(e => new { e.StdId, e.QuestionId, e.ExamId })
                    .HasName("PK_Std_Exam_1");

                entity.ToTable("Std_Exam");

                entity.Property(e => e.StdId).HasColumnName("Std_Id");

                entity.Property(e => e.QuestionId).HasColumnName("Question_Id");

                entity.Property(e => e.ExamId).HasColumnName("Exam_Id");

                entity.Property(e => e.StdAnswer)
                    .HasMaxLength(50)
                    .HasColumnName("Std_Answer");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StdId);

                entity.ToTable("Student");

                entity.Property(e => e.StdId).HasColumnName("std_Id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(50)
                    .HasColumnName("imagePath");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.TopId);

                entity.ToTable("Topic");

                entity.Property(e => e.TopId).HasColumnName("Top_Id");

                entity.Property(e => e.CategId).HasColumnName("Categ_Id");

                entity.Property(e => e.TopName)
                    .HasMaxLength(50)
                    .HasColumnName("Top_Name");

                entity.HasOne(d => d.Categ)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CategId)
                    .HasConstraintName("FK_Topic_Category");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.VidId);

                entity.ToTable("Video");

                entity.Property(e => e.VidId).HasColumnName("Vid_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

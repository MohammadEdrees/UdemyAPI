using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UdemyAPI.Authentication;

#nullable disable

namespace UdemyAPI.Models
{
    public partial class UdemyContext : IdentityDbContext<ApplicationUser,IdentityRole,string>
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
        //public virtual DbSet<InstCr> InstCrs { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StdCr> StdCrs { get; set; }
        public virtual DbSet<StdExam> StdExams { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<SupCateg> SupCategs { get; set; }

        public virtual DbSet<CourseSection> CourseSections { get; set; }
        public virtual DbSet<CourseInCard> CourseInCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Udemy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                    
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<ShoppingCard>( ent =>
            //    {
            //        ent.HasOne(obj => obj.Student).WithOne(obj => obj.ShoppingCard);
            //        ent.HasOne(obj => obj.Instructor).WithOne(obj => obj.ShoppingCard);
            //        ent.HasMany(c => c.Courses).WithOne(c => c.ShoppingCard);
            //    });

            modelBuilder.Entity<SupCateg>(ent =>
            {
                ent.HasOne(e => e.Category).WithMany(e => e.SupCategs).HasForeignKey(e=>e.CategoryId);
                
                //ent.HasMany(e => e.Topics).WithOne(e => e.supCateg);

            });

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

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Top)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TopId).IsRequired();

                //entity.HasOne(o => o.ShoppingCard)
                //.WithMany(o => o.Courses)
                //.HasForeignKey(o => o.CardId);

                entity.HasMany(obj => obj.CourseSections)
                .WithOne(obj => obj.Course).HasForeignKey(obj => obj.CrsId).IsRequired();

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

            //modelBuilder.Entity<InstCr>(entity =>
            //{
            //    entity.HasKey(e => new { e.InstId, e.CrsId });

            //    entity.ToTable("Inst_Crs");

            //    entity.Property(e => e.InstId)
            //        .ValueGeneratedOnAdd()
            //        .HasColumnName("Inst_Id");

            //    entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

            //});

            modelBuilder.Entity<CourseInCard>(entity =>
            {
                entity.HasKey(e => new { e.CId, e.CrsId });
                

            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InstId);

                entity.ToTable("Instructor");

                entity.Property(e => e.InstId).HasColumnName("Inst_Id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Biography).HasMaxLength(50);

                entity.Property(e => e.Communication).HasMaxLength(50);

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.HeadLine).HasMaxLength(50);

                entity.Property(e => e.ImagPath).HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasMany(obj => obj.courses).WithOne(obj => obj.Instructor).HasForeignKey(obj=>obj.InstId).IsRequired();
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
                entity.HasOne(obj => obj.Student).WithMany(obj => obj.StudentCourses);
                entity.HasOne(obj => obj.Course).WithMany(obj => obj.studentCourses);
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

                entity.Property(e => e.StdId).HasColumnName("Std_Id");

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

                entity.Property(e => e.SupCatId).HasColumnName("SupCat_Id");

                entity.Property(e => e.TopName)
                    .HasMaxLength(50)
                    .HasColumnName("Top_Name");
                entity.HasOne(obj => obj.supCateg).WithMany(obj => obj.Topics).HasForeignKey(obj => obj.SupCatId);

            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(e => e.LectureId);

                entity.ToTable("Lecture");

                entity.Property(e => e.LectureId).HasColumnName("Lecture_Id");

                //entity.Property(e => e.SectionId).HasColumnName("Crs_Id");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasOne(obj => obj.CourseSection).WithMany(obj => obj.CourseLecture).HasForeignKey(e => e.SectionId).IsRequired();

            });
           

            OnModelCreatingPartial(modelBuilder);
        }
       

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

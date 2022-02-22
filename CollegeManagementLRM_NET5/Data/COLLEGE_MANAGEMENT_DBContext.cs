using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CollegeManagementLRM_NET5.Data
{
    public partial class COLLEGE_MANAGEMENT_DBContext : DbContext
    {
        public COLLEGE_MANAGEMENT_DBContext()
        {
        }

        public COLLEGE_MANAGEMENT_DBContext(DbContextOptions<COLLEGE_MANAGEMENT_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentGrade> StudentGrades { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse);

                entity.ToTable("COURSES");

                entity.Property(e => e.IdCourse).HasColumnName("ID_COURSE");

                entity.Property(e => e.DsCourse)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DS_COURSE");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudentRegistrationNumber);

                entity.ToTable("STUDENTS");

                entity.HasIndex(e => e.IdCourse, "IX_STUDENTS_ID_COURSE");

                entity.Property(e => e.IdStudentRegistrationNumber).HasColumnName("ID_STUDENT_REGISTRATION_NUMBER");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.IdCourse).HasColumnName("ID_COURSE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdCourse);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasKey(e => e.IdStudentSubject);

                entity.ToTable("STUDENT_GRADES");

                entity.HasIndex(e => e.IdStudentRegistrationNumber, "IX_STUDENT_GRADES_ID_STUDENT_REGISTRATION_NUMBER");

                entity.HasIndex(e => e.IdSubject, "IX_STUDENT_GRADES_ID_SUBJECT");

                entity.Property(e => e.IdStudentSubject).HasColumnName("ID_STUDENT_SUBJECT");

                entity.Property(e => e.Grade)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("GRADE");

                entity.Property(e => e.IdStudentRegistrationNumber).HasColumnName("ID_STUDENT_REGISTRATION_NUMBER");

                entity.Property(e => e.IdSubject).HasColumnName("ID_SUBJECT");

                entity.HasOne(d => d.IdStudentRegistrationNumberNavigation)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.IdStudentRegistrationNumber);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.ToTable("SUBJECTS");

                entity.HasIndex(e => e.IdCourse, "IX_SUBJECTS_ID_COURSE");

                entity.HasIndex(e => e.IdTeacher, "IX_SUBJECTS_ID_TEACHER");

                entity.Property(e => e.IdSubject).HasColumnName("ID_SUBJECT");

                entity.Property(e => e.DsSubject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DS_SUBJECT");

                entity.Property(e => e.IdCourse).HasColumnName("ID_COURSE");

                entity.Property(e => e.IdTeacher).HasColumnName("ID_TEACHER");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdCourse);

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdTeacher);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher);

                entity.Property(e => e.IdTeacher).HasColumnName("ID_TEACHER");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("SALARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

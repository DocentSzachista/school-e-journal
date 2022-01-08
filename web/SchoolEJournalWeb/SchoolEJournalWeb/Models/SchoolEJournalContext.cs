using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class SchoolEJournalContext : DbContext
    {
        public SchoolEJournalContext()
        {
        }

        public SchoolEJournalContext(DbContextOptions<SchoolEJournalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<DisplayAllClass> DisplayAllClasses { get; set; }
        public virtual DbSet<DisplayLesson> DisplayLessons { get; set; }
        public virtual DbSet<DisplaySubjectGrade> DisplaySubjectGrades { get; set; }
        public virtual DbSet<DisplaySubjectInfo> DisplaySubjectInfos { get; set; }
        public virtual DbSet<DisplayUser> DisplayUsers { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradesGroup> GradesGroups { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<LoginDatum> LoginData { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeachersMembership> TeachersMemberships { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HP8R2FA\\KREDEKSQL;Database=SchoolEJournal;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_Attendances_Lessons");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasIndex(e => e.ClassName, "NCD_ClassName");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.SupervisingTeacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SupervisingTeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Classes_Users");
            });

            modelBuilder.Entity<DisplayAllClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DisplayAllClasses");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DisplayLesson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DisplayLessons");

               

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Topic)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DisplaySubjectGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DisplaySubjectGrades");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DisplaySubjectInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DisplaySubjectInfo");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DisplayUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DisplayUsers");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasOne(d => d.GradeGroup)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.GradeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_GradesGroups");
            });

            modelBuilder.Entity<GradesGroup>(entity =>
            {
                entity.HasIndex(e => e.Name, "NCD_GradeName");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GradesGroups)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_GradesGroups_Subjects");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasIndex(e => e.Topic, "NCI_Topic");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Topic)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Subjects_Lessons");
            });

            modelBuilder.Entity<LoginDatum>(entity =>
            {
                entity.HasKey(e => e.LoginDataId);

                entity.HasIndex(e => new { e.Login, e.Password }, "NCI_Login");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginData)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LoginData_Users");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.SubjectName, "NCI_Subject");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Subjects_Classes");
            });

            modelBuilder.Entity<TeachersMembership>(entity =>
            {
                entity.HasKey(e => e.TeacherMembershipId)
                    .HasName("PK_TeachersMembership_1");

                entity.ToTable("TeachersMembership");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeachersMemberships)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TeachersMembership_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachersMemberships)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TeachersMembership_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName, e.Email }, "NCI_UserData");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Users_Classes");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Users_Parent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

       


    }
}

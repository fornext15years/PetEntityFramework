using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetDataCore.Models
{
    public partial class PetDemoContext : DbContext
    {
        public PetDemoContext()
        {
        }

        public PetDemoContext(DbContextOptions<PetDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Surveyor> Surveyor { get; set; }
        public virtual DbSet<SurveyorAssignmentRole> SurveyorAssignmentRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("PetDBConnectionString", EnvironmentVariableTarget.Machine));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.BbpactivityId)
                    .IsRequired()
                    .HasColumnName("BBPActivityID")
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ScheduleDueDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ActivityType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Status");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.HasIndex(e => e.ActivityId)
                    .HasName("ActivityID")
                    .IsUnique();

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.EmailSentDate).HasColumnType("datetime");

                entity.Property(e => e.ScopeOfEos)
                    .HasColumnName("ScopeOfEOs")
                    .HasMaxLength(300);

                entity.HasOne(d => d.Activity)
                    .WithOne(p => p.Assignment)
                    .HasForeignKey<Assignment>(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Activity");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.Property(e => e.Idx).ValueGeneratedNever();

                entity.Property(e => e.ActivityStatus)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Surveyor>(entity =>
            {
                entity.HasKey(e => e.Idx);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(10);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SurveyorAssignmentRole>(entity =>
            {
                entity.HasKey(e => e.Idx)
                    .HasName("PK_SurveyorRole");

                entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

                entity.Property(e => e.SurveyorId).HasColumnName("SurveyorID");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.SurveyorAssignmentRole)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyorRole_Assignment");

                entity.HasOne(d => d.Surveyor)
                    .WithMany(p => p.SurveyorAssignmentRole)
                    .HasForeignKey(d => d.SurveyorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyorRole_Surveyor");
            });
        }
    }
}

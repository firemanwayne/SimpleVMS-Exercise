namespace Infrastructure.Contexts;

using Domain.Models;
using Domain.Models.TimesheetAggregate;
using Domain.Models.WorkerAggregate;

using Microsoft.EntityFrameworkCore;

public partial class SimpleVMSDbContext : DbContext
{
    public SimpleVMSDbContext(DbContextOptions options) : base(options)
    {
    }

    protected SimpleVMSDbContext()
    {
    }

    public DbSet<Buyer> Buyers { get; set; }

    public DbSet<Timesheet> Timesheets { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Worker> Workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Buyer>(entity =>
            {
                entity
                .HasKey(e => e.BuyerId).HasName("PK__Buyer__4B81C1CAC1D7472F");

                entity
                .ToTable("Buyer");

                entity
                    .Property(e => e.BuyerId).HasColumnName("BuyerId");

                entity
                .Property(e => e.Name).HasMaxLength(50);
            });

        modelBuilder
            .Entity<Timesheet>(entity =>
        {
            entity.HasKey(e => e.TimesheetId).HasName("PK__Timeshee__848CBECD93987530");

            entity.ToTable("Timesheet");

            entity.Property(e => e.TimesheetId).HasColumnName("TimesheetId");
            entity.Property(e => e.Hours1).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hours2).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hours3).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hours4).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hours5).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hours6).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hours7).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WorkerId).HasColumnName("WorkerId");

            entity.HasOne(d => d.Worker).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkerTimesheet");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACEBAD64B6");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserId");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK__Worker__077C8806BCD90730");

            entity.ToTable("Worker");

            entity.Property(e => e.WorkerId)
                .ValueGeneratedNever()
                .HasColumnName("WorkerId");
            entity.Property(e => e.BuyerId).HasColumnName("BuyerId");
            entity.Property(e => e.UserId).HasColumnName("UserId");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Workers)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkerBuyer");

            entity.HasOne(d => d.User).WithMany(p => p.Workers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWorker");
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

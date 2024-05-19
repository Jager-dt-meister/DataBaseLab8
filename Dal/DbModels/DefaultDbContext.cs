using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bonuse> Bonuses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Gym> Gyms { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<Sub> Subs { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

	public virtual DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-182AIPK\\SQLEXPRESS;Initial Catalog=TestDB8;Integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bonuse>(entity =>
        {
            entity.HasKey(e => e.BonusId).HasName("PK__Bonuses__D0F870AECEE6111B");

            entity.Property(e => e.BonusId)
                .ValueGeneratedNever()
                .HasColumnName("bonus_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__BF21A4248444C9D4");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("client_id");
            entity.Property(e => e.Birth)
                .HasColumnType("datetime")
                .HasColumnName("birth");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RegDate)
                .HasColumnType("datetime")
                .HasColumnName("reg_date");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EqId).HasName("PK__Equipmen__2A4BF2CA0115CF52");

            entity.Property(e => e.EqId)
                .ValueGeneratedNever()
                .HasColumnName("eq_id");
            entity.Property(e => e.GymId).HasColumnName("gym_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Gym).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.GymId)
                .HasConstraintName("FK__Equipment__gym_i__03F0984C");
        });

        modelBuilder.Entity<Gym>(entity =>
        {
            entity.HasKey(e => e.GymId).HasName("PK__Gyms__3EC25F69363715E6");

            entity.Property(e => e.GymId)
                .ValueGeneratedNever()
                .HasColumnName("gym_id");
            entity.Property(e => e.SportId).HasColumnName("sport_id");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__87071CB9CAA657D6");

            entity.Property(e => e.PurchaseId)
                .ValueGeneratedNever()
                .HasColumnName("purchase_id");
            entity.Property(e => e.BonusId).HasColumnName("bonus_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.SubId).HasColumnName("sub_id");

            entity.HasOne(d => d.Bonus).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.BonusId)
                .HasConstraintName("FK__Purchases__bonus__08B54D69");

            entity.HasOne(d => d.Client).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Purchases__clien__07C12930");

            entity.HasOne(d => d.Sub).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.SubId)
                .HasConstraintName("FK__Purchases__sub_i__09A971A2");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__C46A8A6FB624D024");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("schedule_id");
            entity.Property(e => e.Date)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.GymId).HasColumnName("gym_id");
            entity.Property(e => e.SportId).HasColumnName("sport_id");
            entity.Property(e => e.TrId).HasColumnName("tr_id");

            entity.HasOne(d => d.Gym).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.GymId)
                .HasConstraintName("FK__Schedule__gym_id__06CD04F7");

            entity.HasOne(d => d.Sport).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK__Schedule__sport___04E4BC85");

            entity.HasOne(d => d.Tr).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TrId)
                .HasConstraintName("FK__Schedule__tr_id__05D8E0BE");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("PK__Sports__043926412D43FB3A");

            entity.Property(e => e.SportId)
                .ValueGeneratedNever()
                .HasColumnName("sport_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sub>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("PK__Subs__694106B02C6E27AC");

            entity.Property(e => e.SubId)
                .ValueGeneratedNever()
                .HasColumnName("sub_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrId).HasName("PK__Trainers__ABDBAB18E9A51D85");

            entity.Property(e => e.TrId)
                .ValueGeneratedNever()
                .HasColumnName("tr_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Workhours)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("workhours");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__Visits__375A75E1F7DBC05C");

            entity.Property(e => e.VisitId)
                .ValueGeneratedNever()
                .HasColumnName("visit_id");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Realdate)
                .HasColumnType("datetime")
                .HasColumnName("realdate");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

            entity.HasOne(d => d.Purchase).WithMany(p => p.Visits)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("FK__Visits__purchase__0B91BA14");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Visits)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK__Visits__schedule__0A9D95DB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

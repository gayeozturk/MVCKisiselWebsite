using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCKisiselWebsite.DAL;

public partial class KisiselwebsiteContext : DbContext
{
    public KisiselwebsiteContext()
    {
    }

    public KisiselwebsiteContext(DbContextOptions<KisiselwebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalismaAlani> CalismaAlanis { get; set; }

    public virtual DbSet<GenelBilgi> GenelBilgis { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<Makale> Makales { get; set; }

    public virtual DbSet<Mesaj> Mesajs { get; set; }

    public virtual DbSet<Personel> Personels { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-S6H0KV0O\\SQLEXPRESS;initial catalog=KISISELWEBSITE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalismaAlani>(entity =>
        {
            entity.ToTable("CalismaAlani");
        });

        modelBuilder.Entity<GenelBilgi>(entity =>
        {
            entity.ToTable("GenelBilgi");

            entity.Property(e => e.Logo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.X).HasColumnName("x");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");
        });

        modelBuilder.Entity<Makale>(entity =>
        {
            entity.ToTable("Makale");
        });

        modelBuilder.Entity<Mesaj>(entity =>
        {
            entity.ToTable("Mesaj");
        });

        modelBuilder.Entity<Personel>(entity =>
        {
            entity.ToTable("Personel");

            entity.Property(e => e.Unvan).HasMaxLength(50);
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.ToTable("Slider");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.ToTable("Video");

            entity.Property(e => e.Baslik).HasMaxLength(50);
            entity.Property(e => e.Iframe).HasColumnName("iframe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

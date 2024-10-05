using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvlyCorpBackend.INFRASTRUCTURE.Data;

public partial class ResiduContext : DbContext
{
    public ResiduContext()
    {
    }

    public ResiduContext(DbContextOptions<ResiduContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CondominiumWastes> CondominiumWastes { get; set; }

    public virtual DbSet<Condominiums> Condominiums { get; set; }

    public virtual DbSet<Departments> Departments { get; set; }

    public virtual DbSet<DistrictsUpdatetDTO> Districts { get; set; }

    public virtual DbSet<ManagementCompany> ManagementCompany { get; set; }

    public virtual DbSet<Municipalities> Municipalities { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Provinces> Provinces { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Wastes> Wastes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=residu2;Username=postgres;Password=sistemas", x => x.UseNodaTime());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("CondominiumStatus", new[] { "ACTIVE", "INACTIVE" })
            .HasPostgresEnum("CondominiumWasteStatus", new[] { "READY_TO_COLLECT", "COLLECTED" })
            .HasPostgresEnum("OrderStatus", new[] { "COMPLETED", "PENDING" })
            .HasPostgresEnum("UserRole", new[] { "ADMIN", "CONDOMINIUM_REPRESENTATIVE", "RECYCLER" });

        modelBuilder.Entity<CondominiumWastes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("condominium_wastes_pkey");

            entity.ToTable("condominium_wastes");
            entity.Property(e => e.status).HasColumnName("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CondominiumId).HasColumnName("condominium_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FreeCollection).HasColumnName("free_collection");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WasteId).HasColumnName("waste_id");
            entity.Property(e => e.Weight)
                .HasPrecision(65, 30)
                .HasColumnName("weight");

            entity.HasOne(d => d.Condominium).WithMany(p => p.CondominiumWastes)
                .HasForeignKey(d => d.CondominiumId)
                .HasConstraintName("condominium_wastes_condominium_id_fkey");

            entity.HasOne(d => d.Waste).WithMany(p => p.CondominiumWastes)
                .HasForeignKey(d => d.WasteId)
                .HasConstraintName("condominium_wastes_waste_id_fkey");
        });

        modelBuilder.Entity<Condominiums>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("condominiums_pkey");
            entity.ToTable("condominiums");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp(3) without time zone").HasColumnName("created_at");
            entity.Property(e => e.GoogleMapUrl).HasColumnName("google_map_url");
            entity.Property(e => e.IncorporationDate).HasColumnType("timestamp(3) without time zone").HasColumnName("incorporation_date");
            entity.Property(e => e.MunicipalityId).HasColumnName("municipality_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.ProfitRate).HasPrecision(65, 30).HasColumnName("profit_rate");
            entity.Property(e => e.RepresentativeId).HasColumnName("representative_id");
            entity.Property(e => e.TotalArea).HasPrecision(65, 30).HasColumnName("total_area");
            entity.Property(e => e.UnitTypes).HasColumnName("unit_types");
            entity.Property(e => e.UnitsPerCondominium).HasColumnName("units_per_condominium");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp(3) without time zone");
            entity.HasOne(d => d.Municipality).WithMany(p => p.Condominiums).HasForeignKey(d => d.MunicipalityId).HasConstraintName("condominiums_municipality_id_fkey");
            entity.HasOne(d => d.Representative).WithMany(p => p.Condominiums).HasForeignKey(d => d.RepresentativeId).HasConstraintName("condominiums_representative_id_fkey");
            entity.Property(e => e.status).HasColumnName("status");
        });

        modelBuilder.Entity<Departments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ProvinceId).HasColumnName("provinceId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Province).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("departments_provinceId_fkey");
        });

        modelBuilder.Entity<DistrictsUpdatetDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("districts_pkey");

            entity.ToTable("districts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");

            entity.HasOne(d => d.Department).WithMany(p => p.Districts)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("districts_departmentId_fkey");

            entity.HasOne(d => d.Province).WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("districts_province_id_fkey");
        });

        modelBuilder.Entity<ManagementCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("management_company_pkey");

            entity.ToTable("management_company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Ruc).HasColumnName("ruc");
            entity.Property(e => e.TaxAddress).HasColumnName("tax_address");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");
        });

        modelBuilder.Entity<Municipalities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("municipalities_pkey");

            entity.ToTable("municipalities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CondominiumWasteId).HasColumnName("condominium_waste_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WasteId).HasColumnName("waste_id");

            entity.HasOne(d => d.CondominiumWaste).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CondominiumWasteId)
                .HasConstraintName("orders_condominium_waste_id_fkey");

            entity.HasOne(d => d.Waste).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WasteId)
                .HasConstraintName("orders_waste_id_fkey");
            entity.Property(e => e.Status).HasColumnName("status");
    });

        modelBuilder.Entity<Provinces>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("provinces_pkey");

            entity.ToTable("provinces");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");
            entity.ToTable("users");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp(3) without time zone").HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.DocumentType).HasColumnName("document_type");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp(3) without time zone").HasColumnName("updated_at");
            entity.Property(e => e.Role).HasColumnName("role");    
            entity.HasOne(d => d.Department).WithMany(p => p.Users).HasForeignKey(d => d.DepartmentId).HasConstraintName("users_department_id_fkey");
        });

        modelBuilder.Entity<Wastes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wastes_pkey");

            entity.ToTable("wastes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.MeasurementUnit).HasColumnName("measurement_unit");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(65, 30)
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

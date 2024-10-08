using System;
using System.Collections.Generic;
using infrastructure.DATA;
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

    public virtual DbSet<Districts> Districts { get; set; }

    public virtual DbSet<ManagementCompany> ManagementCompany { get; set; }

    public virtual DbSet<Municipalities> Municipalities { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Provinces> Provinces { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Wastes> Wastes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=residu1.2;Username=postgres;Password=sistemas", x => x.UseNodaTime());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CondominiumWastes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("condominium_wastes_pkey");

            entity.ToTable("condominium_wastes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CondominiumId).HasColumnName("condominium_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FreeCollection).HasColumnName("free_collection");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WasteId).HasColumnName("waste_id");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.Condominium).WithMany(p => p.CondominiumWastes)
                .HasForeignKey(d => d.CondominiumId)
                .HasConstraintName("fk_condominium");

            entity.HasOne(d => d.Waste).WithMany(p => p.CondominiumWastes)
                .HasForeignKey(d => d.WasteId)
                .HasConstraintName("fk_waste");
        });

        modelBuilder.Entity<Condominiums>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("condominiums_pkey");

            entity.ToTable("condominiums");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.GoogleMapUrl)
                .HasMaxLength(255)
                .HasColumnName("google_map_url");
            entity.Property(e => e.IncorporationDate).HasColumnName("incorporation_date");
            entity.Property(e => e.MunicipalityId).HasColumnName("municipality_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
            entity.Property(e => e.ProfitRate)
                .HasPrecision(10, 2)
                .HasColumnName("profit_rate");
            entity.Property(e => e.RepresentativeId).HasColumnName("representative_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalArea)
                .HasPrecision(10, 2)
                .HasColumnName("total_area");
            entity.Property(e => e.UnitTypes)
                .HasMaxLength(255)
                .HasColumnName("unit_types");
            entity.Property(e => e.UnitsPerCondominium).HasColumnName("units_per_condominium");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");

            // Nueva propiedad para management_company_id
            entity.Property(e => e.ManagementCompanyId).HasColumnName("management_company_id");

            // Relación con la tabla ManagementCompany
            entity.HasOne(d => d.ManagementCompany)
                .WithMany(p => p.Condominiums)
                .HasForeignKey(d => d.ManagementCompanyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_management_company");

            entity.HasOne(d => d.Municipality).WithMany(p => p.Condominiums)
                .HasForeignKey(d => d.MunicipalityId)
                .HasConstraintName("fk_municipality");

            entity.HasOne(d => d.Representative).WithMany(p => p.Condominiums)
                .HasForeignKey(d => d.RepresentativeId)
                .HasConstraintName("fk_representative");
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
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Districts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("districts_pkey");

            entity.ToTable("districts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Province).WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("fk_province");
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
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Ruc)
                .HasMaxLength(50)
                .HasColumnName("ruc");
            entity.Property(e => e.TaxAddress)
                .HasMaxLength(255)
                .HasColumnName("tax_address");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(255)
                .HasColumnName("website_url");
        });

        modelBuilder.Entity<Municipalities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("municipalities_pkey");

            entity.ToTable("municipalities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
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
                .HasColumnType("timestamp(3) with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WasteId).HasColumnName("waste_id");

            entity.HasOne(d => d.CondominiumWaste).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CondominiumWasteId)
                .HasConstraintName("fk_condominium_waste");

            entity.HasOne(d => d.Waste).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WasteId)
                .HasConstraintName("fk_waste");
        });

        modelBuilder.Entity<Provinces>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("provinces_pkey");

            entity.ToTable("provinces");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) with time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Department).WithMany(p => p.Provinces)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_department");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Document)
                .HasMaxLength(50)
                .HasColumnName("document");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(50)
                .HasColumnName("document_type");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("photo_url");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.District).WithMany(p => p.Users)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("fk_district");
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
            entity.Property(e => e.MeasurementUnit)
                .HasMaxLength(50)
                .HasColumnName("measurement_unit");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
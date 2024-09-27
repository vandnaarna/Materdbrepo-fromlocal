using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterdbAPI.Models;

public partial class EmpinfoContext : DbContext
{
    public EmpinfoContext()
    {
    }

    public EmpinfoContext(DbContextOptions<EmpinfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Departmentd> Departmentds { get; set; }

    public virtual DbSet<Departmentdb> Departmentdbs { get; set; }

    public virtual DbSet<Empdatum> Empdata { get; set; }

    public virtual DbSet<Empdetail> Empdetails { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<VEmpdepartjoin> VEmpdepartjoins { get; set; }

    public virtual DbSet<VViewofemp> VViewofemps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

       

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptid).HasName("PK__departme__BE2C1AEEAB25C42E");

            entity.ToTable("department");

            entity.Property(e => e.Deptid)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("deptid");
            entity.Property(e => e.Deploc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deploc");
        });

        modelBuilder.Entity<Departmentd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("departmentd");

            entity.Property(e => e.Depid)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("depid");
            entity.Property(e => e.Dloc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dloc");
            entity.Property(e => e.Dname)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("dname");
        });

        modelBuilder.Entity<Departmentdb>(entity =>
        {
            entity.HasKey(e => e.Depid).HasName("PK__departme__00D4AEBBB6199372");

            entity.ToTable("departmentdb");

            entity.HasIndex(e => e.Dloc, "idx_dunique").IsUnique();

            entity.HasIndex(e => e.Dname, "uq_depart").IsUnique();

            entity.Property(e => e.Depid)
                .ValueGeneratedNever()
                .HasColumnName("depid");
            entity.Property(e => e.Dloc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dloc");
            entity.Property(e => e.Dname)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("dname");
        });

        modelBuilder.Entity<Empdatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("empdata");

            entity.HasIndex(e => new { e.Name, e.Salary }, "idx_dname").IsClustered();

            entity.HasIndex(e => e.Salary, "idx_name");

            entity.Property(e => e.Deptid)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("deptid ");
            entity.Property(e => e.Dname)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("dname");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Empdetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("empdetails");

            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.Dname)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("dname");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("Master");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("pid");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Contactno).HasColumnType("numeric(20, 0)");
            entity.Property(e => e.Emai)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("emai");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Pincode).HasColumnType("numeric(20, 0)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product");

            entity.Property(e => e.Productid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("productid");
            entity.Property(e => e.Productname)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("productname");
            entity.Property(e => e.Productno).HasColumnName("productno");
            entity.Property(e => e.Promrp).HasColumnName("promrp");
        });

        modelBuilder.Entity<VEmpdepartjoin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_empdepartjoin");

            entity.Property(e => e.Deploc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("deploc");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<VViewofemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_viewofemp");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

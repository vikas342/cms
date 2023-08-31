using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task__007.Sp_models;

namespace Task__007.Models;

public partial class Task007Context : DbContext
{
    public Task007Context()
    {
    }

    public Task007Context(DbContextOptions<Task007Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ConfDetail> ConfDetails { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<ObjectType> ObjectTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Speaker> Speakers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Getalldata_Sp> Getalldata_Sp { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1CPKOO6\\SQLEXPRESS;Database=Task__007;Trusted_Connection=True;TrustServerCertificate=True;");
    //=> optionsBuilder.UseSqlServer("Server=PC0334\\MSSQL2019;Database=Task__007;Trusted_Connection=True;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddId).HasName("PK__address__273FC77EC1EBD05D");

            entity.ToTable("address");

            entity.Property(e => e.AddId).HasColumnName("add_id");
            entity.Property(e => e.Buildingname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Pincode).HasColumnName("pincode");
            entity.Property(e => e.State).HasColumnName("state");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.City)
                .HasConstraintName("FK__address__city__37A5467C");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK__address__state__38996AB5");
        });

        modelBuilder.Entity<ConfDetail>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__conf_det__D837D05FCEC8DEB6");

            entity.ToTable("conf_details");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Cadd).HasColumnName("cadd");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Food)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("food");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.CaddNavigation).WithMany(p => p.ConfDetails)
                .HasForeignKey(d => d.Cadd)
                .HasConstraintName("FK__conf_detai__cadd__3B75D760");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Hid).HasName("PK__hotels__DF101B018A652D5F");

            entity.ToTable("hotels");

            entity.Property(e => e.Hid).HasColumnName("hid");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Hname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hname");
            entity.Property(e => e.State).HasColumnName("state");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__hotels__cid__3E52440B");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.City)
                .HasConstraintName("FK__hotels__city__3F466844");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK__hotels__state__403A8C7D");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__objects__3213E83FBAE468D7");

            entity.ToTable("objects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Typeid).HasColumnName("typeid");

            entity.HasOne(d => d.Type).WithMany(p => p.Objects)
                .HasForeignKey(d => d.Typeid)
                .HasConstraintName("FK__objects__typeid__34C8D9D1");
        });

        modelBuilder.Entity<ObjectType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__object_t__3213E83FB2131020");

            entity.ToTable("object_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK__orders__C2FFCF13649A464A");

            entity.ToTable("orders");

            entity.Property(e => e.Oid).HasColumnName("oid");
            entity.Property(e => e.BookedDate)
                .HasColumnType("datetime")
                .HasColumnName("booked_date");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Hid).HasColumnName("hid");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__orders__cid__48CFD27E");

            entity.HasOne(d => d.HidNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Hid)
                .HasConstraintName("FK__orders__hid__49C3F6B7");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK__orders__uid__47DBAE45");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__roles__C2B7EDE8ADF0D7CE");

            entity.ToTable("roles");

            entity.Property(e => e.Rid).HasColumnName("rid");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__speakers__DDDFDD3629E9884D");

            entity.ToTable("speakers");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Intime)
                .HasColumnType("datetime")
                .HasColumnName("intime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Outtime)
                .HasColumnType("datetime")
                .HasColumnName("outtime");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Speakers)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__speakers__cid__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__users__DD70126453300451");

            entity.ToTable("users");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasDefaultValueSql("((2))")
                .HasColumnName("role");
            entity.Property(e => e.Uname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("uname");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK__users__role__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

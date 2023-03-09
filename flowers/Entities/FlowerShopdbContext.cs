using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace flowers;

public partial class FlowerShopdbContext : DbContext
{
    public FlowerShopdbContext()
    {
    }

    public FlowerShopdbContext(DbContextOptions<FlowerShopdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderCatalog> OrderCatalogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\ilmir\\Downloads\\flowers\\Flower_shopdb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.IdTovar);

            entity.ToTable("Catalog");

            entity.Property(e => e.IdTovar).HasColumnName("Id_Tovar");
            entity.Property(e => e.Cost)
                .HasColumnType("FLOAT")
                .HasColumnName("cost");
            entity.Property(e => e.Name)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("name");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Text)
                .HasColumnType("NVARCHAR(1000)")
                .HasColumnName("text");
            entity.Property(e => e.Type)
                .HasColumnType("NVARCHAR(20)")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.ToTable("Client");

            entity.Property(e => e.IdClient)
                .ValueGeneratedNever()
                .HasColumnName("Id_Client");
            entity.Property(e => e.Money)
                .HasColumnType("FLOAT")
                .HasColumnName("money");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Clients)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.IdManager);

            entity.ToTable("Manager");

            entity.Property(e => e.IdManager)
                .ValueGeneratedNever()
                .HasColumnName("Id_Manager");
            entity.Property(e => e.Position)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasColumnType("FLOAT")
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Managers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order");

            entity.Property(e => e.IdOrder).HasColumnName("Id_Order");
            entity.Property(e => e.Address)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("address");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.Date)
                .HasColumnType("DATE")
                .HasColumnName("date");
        });

        modelBuilder.Entity<OrderCatalog>(entity =>
        {
            entity.HasKey(e => e.IdOrderCatalog);

            entity.ToTable("Order_Catalog");

            entity.Property(e => e.IdOrderCatalog).HasColumnName("Id_Order_Catalog");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TovarId).HasColumnName("Tovar_Id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderCatalogs)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tovar).WithMany(p => p.OrderCatalogs)
                .HasForeignKey(d => d.TovarId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Address)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("address");
            entity.Property(e => e.Login)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("login");
            entity.Property(e => e.Mail)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasColumnType("NVARCHAR(11)")
                .HasColumnName("phone");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Role)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("role");
            entity.Property(e => e.SecondName)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("second_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

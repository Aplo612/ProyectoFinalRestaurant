using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalRestaurant.Models;

public partial class RestaurantC : DbContext
{
    public RestaurantC()
    {
    }

    public RestaurantC(DbContextOptions<RestaurantC> options)
        : base(options)
    {
    }

    public virtual DbSet<Boletum> Boleta { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=SQL8005.site4now.net;Initial Catalog=db_a9b253_limachi612;User Id=db_a9b253_limachi612_admin;Password=limachimauro612");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boletum>(entity =>
        {
            entity.HasKey(e => e.IdBoleta);

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Boleta)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Boleta_Pedidos");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetallePedido);

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedidos_Pedidos");

            entity.HasOne(d => d.IdPlatoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPlato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedidos_Platos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.IdPlato);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF973FE17B02");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

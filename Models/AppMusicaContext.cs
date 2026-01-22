using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace AppMusicaV1.Models;

public partial class AppMusicaContext : DbContext
{
    public AppMusicaContext()
    {
    }

    public AppMusicaContext(DbContextOptions<AppMusicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Albumes> Albumes { get; set; }

    public virtual DbSet<GenerosMusicales> GenerosMusicales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Albumes>(entity =>
        {
            entity.HasKey(e => e.IdAlbum).HasName("PK__Albumes__7414CFD6EE345A74");

            entity.Property(e => e.IdAlbum).HasColumnName("id_album");
            entity.Property(e => e.anioLanzamiento).HasColumnName("año_lanzamiento");
            entity.Property(e => e.IdGenero).HasColumnName("id_genero");
            entity.Property(e => e.NombreArtista)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("nombre_artista");
            entity.Property(e => e.Titulo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.oGeneroMusical).WithMany(p => p.Albumes)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Albumes__id_gene__398D8EEE");
        });

        modelBuilder.Entity<GenerosMusicales>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__GenerosM__99A8E4F99AB91DAE");

            entity.Property(e => e.IdGenero).HasColumnName("id_genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

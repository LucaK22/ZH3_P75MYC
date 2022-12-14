using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZH3_P75MYC.Models;

public partial class FilmekContext : DbContext
{
    public FilmekContext()
    {
    }

    public FilmekContext(DbContextOptions<FilmekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=softeng-database.database.windows.net;Initial Catalog=Filmek;Persist Security Info=True;User ID=hallgato;Password=Password123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("Genre_ID");
            entity.Property(e => e.Genre1)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Genre");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AudienceScore).HasColumnName("Audience_score");
            entity.Property(e => e.GenreId).HasColumnName("Genre_ID");
            entity.Property(e => e.StudioId)
                .HasDefaultValueSql("((14))")
                .HasColumnName("Studio_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_GenreID");

            entity.HasOne(d => d.Studio).WithMany(p => p.Movies)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_StudioID");
        });

        modelBuilder.Entity<Studio>(entity =>
        {
            entity.ToTable("Studio");

            entity.Property(e => e.StudioId).HasColumnName("Studio_ID");
            entity.Property(e => e.Studio1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("Studio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

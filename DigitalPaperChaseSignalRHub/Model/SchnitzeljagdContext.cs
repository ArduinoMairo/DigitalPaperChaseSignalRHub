using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalPaperChaseSignalRHub.Model
{
    public partial class SchnitzeljagdContext : DbContext
    {
        /*
        public SchnitzeljagdContext()
        {
        }
        */

        public SchnitzeljagdContext(DbContextOptions<SchnitzeljagdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fachbereiche> Fachbereiches { get; set; }
        public virtual DbSet<Fragen> Fragens { get; set; }
        public virtual DbSet<Kategorien> Kategoriens { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Loesungen> Loesungens { get; set; }
        public virtual DbSet<Punkte> Punktes { get; set; }
        public virtual DbSet<Schnitzeljagden> Schnitzeljagdens { get; set; }
        public virtual DbSet<Spieler> Spielers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TU3FS7TJ\\SQLExpress;Database=Schnitzeljagd;Trusted_Connection=True;");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Fachbereiche>(entity =>
            {
                entity.HasKey(e => e.FachbereichId)
                    .HasName("PK_Fachbereich");

                entity.ToTable("Fachbereiche");

                entity.Property(e => e.FachbereichId).HasColumnName("Fachbereich_ID");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Fragen>(entity =>
            {
                entity.HasKey(e => e.FragenId);

                entity.ToTable("Fragen");

                entity.Property(e => e.FragenId).HasColumnName("Fragen_ID");

                entity.Property(e => e.Inhalt)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.KategorieId).HasColumnName("Kategorie_ID");

                entity.HasOne(d => d.Kategorie)
                    .WithMany(p => p.Fragens)
                    .HasForeignKey(d => d.KategorieId)
                    .HasConstraintName("FK_Fragen_Kategorien");
            });

            modelBuilder.Entity<Kategorien>(entity =>
            {
                entity.HasKey(e => e.KategorieId);

                entity.ToTable("Kategorien");

                entity.Property(e => e.KategorieId).HasColumnName("Kategorie_ID");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FachbereichId).HasColumnName("Fachbereich_ID");

                entity.HasOne(d => d.Fachbereich)
                    .WithMany(p => p.Kategoriens)
                    .HasForeignKey(d => d.FachbereichId)
                    .HasConstraintName("FK_Kategorien_Fachbereich");
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.Property(e => e.LinkId).HasColumnName("Link_ID");

                entity.Property(e => e.QuellfrageId).HasColumnName("Quellfrage_ID");

                entity.Property(e => e.SchnitzeljagdId).HasColumnName("Schnitzeljagd_ID");

                entity.Property(e => e.ZielfrageId).HasColumnName("Zielfrage_ID");

                entity.HasOne(d => d.Schnitzeljagd)
                    .WithMany(p => p.Links)
                    .HasForeignKey(d => d.SchnitzeljagdId)
                    .HasConstraintName("FK_Links_Schnitzeljagden");
            });

            modelBuilder.Entity<Loesungen>(entity =>
            {
                entity.HasKey(e => e.LoesungId);

                entity.ToTable("Loesungen");

                entity.Property(e => e.LoesungId).HasColumnName("Loesung_ID");

                entity.Property(e => e.FragenId).HasColumnName("Fragen_ID");

                entity.Property(e => e.Inhalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Fragen)
                    .WithMany(p => p.Loesungens)
                    .HasForeignKey(d => d.FragenId)
                    .HasConstraintName("FK_Loesungen_Fragen");
            });

            modelBuilder.Entity<Punkte>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Punkte");

                entity.Property(e => e.Punkte1).HasColumnName("Punkte");

                entity.Property(e => e.SchnitzeljagdId).HasColumnName("Schnitzeljagd_ID");

                entity.Property(e => e.SpielerId).HasColumnName("Spieler_ID");

                entity.HasOne(d => d.Schnitzeljagd)
                    .WithMany()
                    .HasForeignKey(d => d.SchnitzeljagdId)
                    .HasConstraintName("FK_Punkte_Schnitzeljagden");

                entity.HasOne(d => d.Spieler)
                    .WithMany()
                    .HasForeignKey(d => d.SpielerId)
                    .HasConstraintName("FK_Punkte_Spieler");
            });

            modelBuilder.Entity<Schnitzeljagden>(entity =>
            {
                entity.HasKey(e => e.SchnitzeljagdId);

                entity.ToTable("Schnitzeljagden");

                entity.Property(e => e.SchnitzeljagdId).HasColumnName("Schnitzeljagd_ID");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KategorieId).HasColumnName("Kategorie_ID");

                entity.HasOne(d => d.Kategorie)
                    .WithMany(p => p.Schnitzeljagdens)
                    .HasForeignKey(d => d.KategorieId)
                    .HasConstraintName("FK_Schnitzeljagden_Kategorien");
            });

            modelBuilder.Entity<Spieler>(entity =>
            {
                entity.ToTable("Spieler");

                entity.Property(e => e.SpielerId).HasColumnName("Spieler_ID");

             

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

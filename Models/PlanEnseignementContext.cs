using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class PlanEnseignementContext : DbContext
    {
        public PlanEnseignementContext()
        {
        }

        public PlanEnseignementContext(DbContextOptions<PlanEnseignementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnneeUniversitaire> AnneeUniversitaire { get; set; }
        public virtual DbSet<AnneeUniversitaireFiliere> AnneeUniversitaireFiliere { get; set; }
        public virtual DbSet<AnneeUniversitaireNiveauParcoursPeriode> AnneeUniversitaireNiveauParcoursPeriode { get; set; }
        public virtual DbSet<AnneeUniversitaireNomOption> AnneeUniversitaireNomOption { get; set; }
        public virtual DbSet<Departement> Departement { get; set; }
        public virtual DbSet<Filiere> Filiere { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Niveau> Niveau { get; set; }
        public virtual DbSet<Parcours> Parcours { get; set; }
        public virtual DbSet<TypeDiplome> TypeDiplome { get; set; }
        public virtual DbSet<TypePeriode> TypePeriode { get; set; }
        public virtual DbSet<UniteEnseignement> UniteEnseignement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RIP3HIO\\SQLEXPRESS;Database=PlanEnseignement;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnneeUniversitaire>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");

                entity.Property(e => e.EtatCharges)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EtatPlanEtudes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnneeUniversitaireFiliere>(entity =>
            {
                entity.Property(e => e.CodeAnneeUniversitaire)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeAnneeUniversitaireNavigation)
                    .WithMany(p => p.AnneeUniversitaireFiliere)
                    .HasForeignKey(d => d.CodeAnneeUniversitaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireFiliere_AnneeUniversitaire");

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.AnneeUniversitaireFiliere)
                    .HasForeignKey(d => d.IdFiliere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireFiliere_Filiere");
            });

            modelBuilder.Entity<AnneeUniversitaireNiveauParcoursPeriode>(entity =>
            {
                entity.Property(e => e.CodeAnneeUniversitaire)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NbGroupesCi).HasColumnName("NbGroupesCI");

                entity.Property(e => e.NbGroupesTd).HasColumnName("NbGroupesTD");

                entity.Property(e => e.NbGroupesTp).HasColumnName("NbGroupesTP");

                entity.Property(e => e.Periode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeAnneeUniversitaireNavigation)
                    .WithMany(p => p.AnneeUniversitaireNiveauParcoursPeriode)
                    .HasForeignKey(d => d.CodeAnneeUniversitaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireNiveauParcoursPeriode_AnneeUniversitaire");

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.AnneeUniversitaireNiveauParcoursPeriode)
                    .HasForeignKey(d => d.IdFiliere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireNiveauParcoursPeriode_Filiere");

                entity.HasOne(d => d.IdNiveauNavigation)
                    .WithMany(p => p.AnneeUniversitaireNiveauParcoursPeriode)
                    .HasForeignKey(d => d.IdNiveau)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireNiveauParcoursPeriode_Niveau");

                entity.HasOne(d => d.IdParcoursNavigation)
                    .WithMany(p => p.AnneeUniversitaireNiveauParcoursPeriode)
                    .HasForeignKey(d => d.IdParcours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireNiveauParcoursPeriode_Parcours");
            });

            modelBuilder.Entity<AnneeUniversitaireNomOption>(entity =>
            {
                entity.Property(e => e.CodeAnneeUniversitaire)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrg)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeAnneeUniversitaireNavigation)
                    .WithMany(p => p.AnneeUniversitaireNomOption)
                    .HasForeignKey(d => d.CodeAnneeUniversitaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnneeUniversitaireNomOption_AnneeUniversitaire");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.AnneeUniversitaireNomOption)
                    .HasForeignKey(d => d.IdModule)
                    .HasConstraintName("FK_AnneeUniversitaireNomOption_Module");
            });

            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeDepartement)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeTypeDiplome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeTypePeriode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Domaine)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrege)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Mention)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeHabilitation)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeDepartementNavigation)
                    .WithMany(p => p.Filiere)
                    .HasForeignKey(d => d.CodeDepartement)
                    .HasConstraintName("FK_Filiere_Departement");

                entity.HasOne(d => d.CodeTypeDiplomeNavigation)
                    .WithMany(p => p.Filiere)
                    .HasForeignKey(d => d.CodeTypeDiplome)
                    .HasConstraintName("FK_Filiere_TypeDiplome");

                entity.HasOne(d => d.CodeTypePeriodeNavigation)
                    .WithMany(p => p.Filiere)
                    .HasForeignKey(d => d.CodeTypePeriode)
                    .HasConstraintName("FK_Filiere_TypePeriode");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.IdModule)
                    .HasName("PK_Module_1");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeFiliere)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeNiveau)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CodeParcours)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrege)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RegimeExamen)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UniteVolumeHoraire)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.VolumeCi).HasColumnName("VolumeCI");

                entity.Property(e => e.VolumeTd).HasColumnName("VolumeTD");

                entity.Property(e => e.VolumeTp).HasColumnName("VolumeTP");

                entity.HasOne(d => d.IdUniteEnseignementNavigation)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.IdUniteEnseignement)
                    .HasConstraintName("FK_Module_UniteEnseignement");
            });

            modelBuilder.Entity<Niveau>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrege)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.Niveau)
                    .HasForeignKey(d => d.IdFiliere)
                    .HasConstraintName("FK_Niveau_Filiere");
            });

            modelBuilder.Entity<Parcours>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrg)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeDebut)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeFin)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeHabilitation)
                    .HasColumnName("periodeHabilitation")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.Parcours)
                    .HasForeignKey(d => d.IdFiliere)
                    .HasConstraintName("FK_Parcours_Filiere");
            });

            modelBuilder.Entity<TypeDiplome>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrg)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypePeriode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrg)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UniteEnseignement>(entity =>
            {
                entity.HasKey(e => e.IdUniteEnseignement);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAbrg)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleAr)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IntituleFr)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nature)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNiveauNavigation)
                    .WithMany(p => p.UniteEnseignement)
                    .HasForeignKey(d => d.IdNiveau)
                    .HasConstraintName("FK_UniteEnseignement_Niveau");

                entity.HasOne(d => d.IdParcoursNavigation)
                    .WithMany(p => p.UniteEnseignement)
                    .HasForeignKey(d => d.IdParcours)
                    .HasConstraintName("FK_UniteEnseignement_Parcours");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

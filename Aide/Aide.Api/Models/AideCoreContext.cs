using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aide.Api.Models
{
    public partial class AideCoreContext : IdentityDbContext<AideWebUser>
    {
        public AideCoreContext()
        {
        }

        public AideCoreContext(DbContextOptions<AideCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionReponse> QuestionReponse { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<QuestionTypeView> QuestionTypeView { get; set; }
        public virtual DbSet<Quizz> Quizz { get; set; }
        public virtual DbSet<QuizzMatiere> QuizzMatiere { get; set; }
        public virtual DbSet<QuizzMatiereView> QuizzMatiereView { get; set; }
        public virtual DbSet<QuizzQuestionReponsePointView> QuizzQuestionReponsePointView { get; set; }
        public virtual DbSet<QuizzQuestionTypeView> QuizzQuestionTypeView { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<AideWebUser> Utilisateur { get; set; }
        public virtual DbSet<UtilisateurQuestionReponse> UtilisateurQuestionReponse { get; set; }
        public virtual DbSet<UtilisateurRoleView> UtilisateurRoleView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aide.Core;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8AECC79B9");

                entity.Property(e => e.Points).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdentityKeyQuestionTypeNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdentityKeyQuestionType)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Question__Identi__3A81B327");

                entity.HasOne(d => d.IdentityKeyQuizzNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdentityKeyQuizz)
                    .HasConstraintName("FK__Question__Identi__398D8EEE");
            });

            modelBuilder.Entity<QuestionReponse>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B884677EF8");

                entity.Property(e => e.Bon).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdentityKeyQuestionNavigation)
                    .WithMany(p => p.QuestionReponse)
                    .HasForeignKey(d => d.IdentityKeyQuestion)
                    .HasConstraintName("FK__QuestionR__Ident__3B75D760");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B81BFB3504");
            });

            modelBuilder.Entity<QuestionTypeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuestionTypeView");
            });

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Quizz__796424B8DCB92EBE");

                entity.Property(e => e.Titre).HasDefaultValueSql("('sans nom')");

                entity.HasOne(d => d.IdentityKeyMatiereNavigation)
                    .WithMany(p => p.Quizz)
                    .HasForeignKey(d => d.IdentityKeyMatiere)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Quizz__IdentityK__3C69FB99");
            });

            modelBuilder.Entity<QuizzMatiere>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__QuizzMat__796424B8F5DE1F98");

                entity.Property(e => e.Titre).HasDefaultValueSql("('sans nom')");
            });

            modelBuilder.Entity<QuizzMatiereView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuizzMatiereView");
            });

            modelBuilder.Entity<QuizzQuestionReponsePointView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuizzQuestionReponsePointView");
            });

            modelBuilder.Entity<QuizzQuestionTypeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuizzQuestionTypeView");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Role__796424B82D978144");

                entity.Property(e => e.IdentityKey).ValueGeneratedNever();
            });

            modelBuilder.Entity<AideWebUser>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Utilisat__796424B89864DB19");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Utilisat__A9D10534CB6F74B4")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Utilisat__3214EC06CACB1DD4")
                    .IsUnique();

                entity.Property(e => e.IdentityKey).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.IdentityKeyRoleNavigation)
                    .WithMany(p => p.Utilisateur)
                    .HasForeignKey(d => d.IdentityKeyRole)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Utilisate__Ident__3D5E1FD2");
            });

            modelBuilder.Entity<UtilisateurQuestionReponse>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Utilisat__796424B8CD71FE65");

                entity.HasIndex(e => new { e.IdentityKeyUser, e.IdentityKeyQuestionReponse, e.Essaie })
                    .HasName("essaie_unique")
                    .IsUnique();

                entity.Property(e => e.IdentityKey).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Essaie).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdentityKeyQuestionReponseNavigation)
                    .WithMany(p => p.UtilisateurQuestionReponse)
                    .HasForeignKey(d => d.IdentityKeyQuestionReponse)
                    .HasConstraintName("FK__Utilisate__Ident__3F466844");

                entity.HasOne(d => d.IdentityKeyUserNavigation)
                    .WithMany(p => p.UtilisateurQuestionReponse)
                    .HasForeignKey(d => d.IdentityKeyUser)
                    .HasConstraintName("FK__Utilisate__Ident__3E52440B");
            });

            modelBuilder.Entity<UtilisateurRoleView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UtilisateurRoleView");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

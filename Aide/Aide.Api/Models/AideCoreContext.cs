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
        public virtual DbSet<UtilisateurRoleView> UtilisateurRoleView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=Aide.Core;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8F25F8EE8");

                entity.Property(e => e.Points).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdentityKeyQuestionTypeNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdentityKeyQuestionType)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Question__Identi__35BCFE0A");

                entity.HasOne(d => d.IdentityKeyQuizzNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdentityKeyQuizz)
                    .HasConstraintName("FK__Question__Identi__34C8D9D1");
            });

            modelBuilder.Entity<QuestionReponse>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8006F3F40");

                entity.Property(e => e.Bon).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdentityKeyQuestionNavigation)
                    .WithMany(p => p.QuestionReponse)
                    .HasForeignKey(d => d.IdentityKeyQuestion)
                    .HasConstraintName("FK__QuestionR__Ident__36B12243");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8C37FA56A");
            });

            modelBuilder.Entity<QuestionTypeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuestionTypeView");
            });

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Quizz__796424B8E025ADAE");

                entity.Property(e => e.Titre).HasDefaultValueSql("('sans nom')");

                entity.HasOne(d => d.IdentityKeyMatiereNavigation)
                    .WithMany(p => p.Quizz)
                    .HasForeignKey(d => d.IdentityKeyMatiere)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Quizz__IdentityK__37A5467C");
            });

            modelBuilder.Entity<QuizzMatiere>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__QuizzMat__796424B86BB8BCB2");

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
            });

            modelBuilder.Entity<AideWebUser>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__tmp_ms_x__796424B8C71C3F33");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__tmp_ms_x__A9D10534211271F1")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__tmp_ms_x__3214EC067DAE0516")
                    .IsUnique();

                entity.HasOne(d => d.IdentityKeyRoleNavigation)
                    .WithMany(p => p.Utilisateur)
                    .HasForeignKey(d => d.IdentityKeyRole)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Utilisate__Ident__4222D4EF");
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

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetInternetQuizer.Data
{
    public partial class AideCoreContext : DbContext
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
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<UtilisateurRoleView> UtilisateurRoleView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aide.Core;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8E5F0AFBB");

                entity.Property(e => e.Points).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdentityKeyQuestionTypeNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdentityKeyQuestionType)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Question__Identi__36B12243");

                entity.HasOne(d => d.IdentityKeyQuizzNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdentityKeyQuizz)
                    .HasConstraintName("FK__Question__Identi__35BCFE0A");
            });

            modelBuilder.Entity<QuestionReponse>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8FB5B1F6B");

                entity.Property(e => e.Bon).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdentityKeyQuestionNavigation)
                    .WithMany(p => p.QuestionReponse)
                    .HasForeignKey(d => d.IdentityKeyQuestion)
                    .HasConstraintName("FK__QuestionR__Ident__37A5467C");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Question__796424B8CDABF0EA");
            });

            modelBuilder.Entity<QuestionTypeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("QuestionTypeView");
            });

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Quizz__796424B89010E207");

                entity.Property(e => e.Titre).HasDefaultValueSql("('sans nom')");

                entity.HasOne(d => d.IdentityKeyMatiereNavigation)
                    .WithMany(p => p.Quizz)
                    .HasForeignKey(d => d.IdentityKeyMatiere)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Quizz__IdentityK__38996AB5");
            });

            modelBuilder.Entity<QuizzMatiere>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__QuizzMat__796424B83685E3B3");

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
                    .HasName("PK__Role__796424B8F2BE68BC");

                entity.Property(e => e.IdentityKey).ValueGeneratedNever();
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__Utilisat__796424B8576DE253");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Utilisat__A9D10534361EE34A")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Utilisat__3214EC062384D71E")
                    .IsUnique();

                entity.Property(e => e.IdentityKey).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.IdentityKeyRoleNavigation)
                    .WithMany(p => p.Utilisateur)
                    .HasForeignKey(d => d.IdentityKeyRole)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Utilisate__Ident__398D8EEE");
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

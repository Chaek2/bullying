using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace REYSAPITEST1.Models;

public partial class ReysContext : DbContext
{
    public ReysContext() {}

    public ReysContext(DbContextOptions<ReysContext> options): base(options) {}

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryApp> CategoryApps { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<FolderApp> FolderApps { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Raiting> Raitings { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagApp> TagApps { get; set; }

    public virtual DbSet<Version> Versions { get; set; }

    public virtual DbSet<VersionApp> VersionApps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1, 1444;Initial Catalog=REYS;Integrated Security=True;Persist Security Info=True;User ID=sa;Password=Password123;Encrypt=True;Trust Server Certificate=True;Integrated Security=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.IdApplication).HasName("PK__Applicat__A1DFC5F9EC726403");

            entity.ToTable("Application");

            entity.HasIndex(e => new { e.Title, e.Author }, "UQ_Application_Title_Author").IsUnique();

            entity.Property(e => e.IdApplication).HasColumnName("ID_Application");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Title).HasName("PK__Category__2CB664DDAFEDED3C");

            entity.ToTable("Category");

            entity.Property(e => e.Title)
            .HasColumnName("Title")
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CategoryApp>(entity =>
        {
            entity.HasKey(e => e.IdCategoryApp).HasName("PK__Category__517D9425A2571A0E");

            entity.ToTable("Category_App");

            entity.Property(e => e.IdCategoryApp).HasColumnName("ID_Category_App");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);

        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.IdFeedback).HasName("PK__Feedback__7CA05C3F0DD95255");

            entity.ToTable("Feedback");

            entity.Property(e => e.IdFeedback).HasColumnName("ID_Feedback");
            entity.Property(e => e.Dates).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasColumnType("text");

        });

        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.IdFolder).HasName("PK__Folder__D09E3B1A29EB4D11");

            entity.ToTable("Folder");

            entity.HasIndex(e => new { e.Email, e.Title }, "UQ_Folder_Email_Title").IsUnique();

            entity.Property(e => e.IdFolder).HasColumnName("ID_Folder");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

        });

        modelBuilder.Entity<FolderApp>(entity =>
        {
            entity.HasKey(e => e.IdFolderApp).HasName("PK__Folder_A__FB0D6A3C06FAE70F");

            entity.ToTable("Folder_App");

            entity.Property(e => e.IdFolderApp).HasColumnName("ID_Folder_App");

        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Person__A9D1053516077450");

            entity.ToTable("Person");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Post)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Verified).HasDefaultValue(false);

        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Title).HasName("PK__Post__2CB664DDDBE909D6");

            entity.ToTable("Post");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Raiting>(entity =>
        {
            entity.HasKey(e => e.IdRaiting).HasName("PK__Raiting__5AB9929EF1F1443E");

            entity.ToTable("Raiting");

            entity.Property(e => e.IdRaiting).HasColumnName("ID_Raiting");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Title).HasName("PK__Tag__2CB664DD53572190");

            entity.ToTable("Tag");

            entity.Property(e => e.Title)
            .HasColumnName("Title")
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TagApp>(entity =>
        {
            entity.HasKey(e => e.IdTagApp).HasName("PK__Tag_App__90DC121148A47D13");

            entity.ToTable("Tag_App");

            entity.Property(e => e.IdTagApp).HasColumnName("ID_Tag_App");
            entity.Property(e => e.Tag)
                .HasMaxLength(100)
                .IsUnicode(false);

        });

        modelBuilder.Entity<Version>(entity =>
        {
            entity.HasKey(e => e.IdVersion).HasName("PK__Version__CA3F205096B0C44E");

            entity.ToTable("Version");

            entity.HasIndex(e => new { e.Title, e.Path }, "UQ_Title_Version_Path").IsUnique();

            entity.Property(e => e.IdVersion).HasColumnName("ID_Version");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VersionApp>(entity =>
        {
            entity.HasKey(e => e.IdVersionApp).HasName("PK__Version___B4F86481191ED876");

            entity.ToTable("Version_App");

            entity.Property(e => e.IdVersionApp).HasColumnName("ID_Version_App");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

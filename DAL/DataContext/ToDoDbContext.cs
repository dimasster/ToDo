using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
    ;

public partial class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=ToDoDB;Encrypt=False;TrustServerCertificate=False;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.ListId).HasName("PK__Lists__7B9EF13579FE8608");

            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('some text')")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PK__Notes__CEDD0FA40A70EF96");

            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.IsDone).HasColumnName("is_done");
            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.NoteValue)
                .HasColumnType("numeric(4, 1)")
                .HasColumnName("note_value");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.NoteUnitType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("unit_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

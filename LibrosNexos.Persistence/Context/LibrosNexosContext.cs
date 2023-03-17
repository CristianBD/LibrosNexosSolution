using LibrosNexos.Domain.Entities;
using LibrosNexos.Persistence.Context.IContext;
using Microsoft.EntityFrameworkCore;

namespace LibrosNexos.Persistence.Context;

public partial class LibrosNexosContext : DbContext, ILibrosNexosContext
{
    public LibrosNexosContext()
    {
    }

    public LibrosNexosContext(DbContextOptions<LibrosNexosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TBL_AUTORES> TBL_AUTORES { get; set; }

    public virtual DbSet<TBL_EDITORIALES> TBL_EDITORIALES { get; set; }

    public virtual DbSet<TBL_GENEROS> TBL_GENEROS { get; set; }

    public virtual DbSet<TBL_LIBROS> TBL_LIBROS { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\Pruebas;Initial Catalog=LibrosNexos;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TBL_AUTORES>(entity =>
        {
            entity.HasKey(e => e.AU_ID).HasName("PK__TBL_AUTO__312323042F96E6B6");

            entity.Property(e => e.AU_CIUDAD_PROCEDENCIA).HasMaxLength(150);
            entity.Property(e => e.AU_EMAIL).HasMaxLength(200);
            entity.Property(e => e.AU_FECHA_NACIMIENTO).HasColumnType("datetime");
            entity.Property(e => e.AU_NOMBRE_COMPLETO).HasMaxLength(150);
        });

        modelBuilder.Entity<TBL_EDITORIALES>(entity =>
        {
            entity.HasKey(e => e.ED_ID).HasName("PK__TBL_EDIT__B9CE0418E936887D");

            entity.Property(e => e.ED_DIRECCION).HasMaxLength(150);
            entity.Property(e => e.ED_EMAIL).HasMaxLength(200);
            entity.Property(e => e.ED_NOMBRE).HasMaxLength(150);
            entity.Property(e => e.ED_TELEFONO).HasMaxLength(20);
        });

        modelBuilder.Entity<TBL_GENEROS>(entity =>
        {
            entity.HasKey(e => e.G_ID);

            entity.Property(e => e.G_NOMBRE).HasMaxLength(150);
        });

        modelBuilder.Entity<TBL_LIBROS>(entity =>
        {
            entity.HasKey(e => e.LI_ID).HasName("PK__TBL_LIBR__C70D355DD565C54B");

            entity.Property(e => e.LI_TITULO).HasMaxLength(150);

            entity.HasOne(d => d.LI_AUTOR).WithMany(p => p.TBL_LIBROS)
                .HasForeignKey(d => d.LI_AUTOR_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_LIBRO__LI_AU__2B3F6F97");

            entity.HasOne(d => d.LI_EDITORIAL).WithMany(p => p.TBL_LIBROS)
                .HasForeignKey(d => d.LI_EDITORIAL_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TBL_LIBRO__LI_ED__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

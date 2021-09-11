using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNxs.Entities;
using PruebaNxs.Models;

namespace PruebaNxs.DataAccess
{
   public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Libro> Libros { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseOracle("Data Source=localhost:1521/xe;Password=root;User Id=nexosuser;Connection Timeout=120;");
            }
        }
       
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ignorar la clase Entity
            modelBuilder.Ignore<Entity>();
            /*
            modelBuilder.HasDefaultSchema("NEXOSUSER")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("PK_Autors");

                entity.ToTable("AUTORS");

                entity.Property(e => e.id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDAUTOR");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHANACIMIENTO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("PK_Libros");

                entity.ToTable("LIBROS");

                entity.Property(e => e.id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDLIBRO");

                entity.Property(e => e.Ano)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ANO");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GENERO");

                entity.Property(e => e.Idautor)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDAUTOR");

                entity.Property(e => e.Nopaginas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOPAGINAS");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Autors_IdLibro");
            });

            modelBuilder.HasSequence("AUTOR_SEQ");

            modelBuilder.HasSequence("LIBRO_SEQ");
            */
            base.OnModelCreating(modelBuilder);

        }
    }
}

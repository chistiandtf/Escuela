using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace School.Models
{
    public partial class EscolarContext : DbContext
    {
        public EscolarContext()
        {
        }

        public EscolarContext(DbContextOptions<EscolarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; }
        public virtual DbSet<Clase> Clases { get; set; }
        public virtual DbSet<Clasealumno> Clasealumnos { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Grado> Grados { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<InscripcionEstudiante> InscripcionEstudiantes { get; set; }
        public virtual DbSet<Materium> Materia { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Notum> Nota { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Representante> Representantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=CHRISTIAN;Database=Escolar;user=sa;password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.Estudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Estudiantes");

                entity.HasOne(d => d.GradoNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.Grado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_grado");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.Materia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Materia");

                entity.HasOne(d => d.NotasNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.Notas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Nota");

                entity.HasOne(d => d.PeriodoNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_periodo");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.Idclase)
                    .HasName("PK__clase__3213E83F5F2879A0");

                entity.Property(e => e.Materia).IsFixedLength(true);

                entity.HasOne(d => d.GradoNavigation)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Grado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clase_grado");

                entity.HasOne(d => d.HorarioNavigation)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Horario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clase_horario");

                entity.HasOne(d => d.PeriodoNavigation)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clase_Materia");

                entity.HasOne(d => d.Periodo1)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clase_periodo");

                entity.HasOne(d => d.ProfesorNavigation)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.Profesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clase_profesor");
            });

            modelBuilder.Entity<Clasealumno>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__clasealu__3213E83F242BB615");

                entity.HasOne(d => d.ClaseNavigation)
                    .WithMany(p => p.Clasealumnos)
                    .HasForeignKey(d => d.Clase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clasealumno_clase");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.Clasealumnos)
                    .HasForeignKey(d => d.Estudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clasealumno_Estudiantes");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__AEFFDBC53E1C0AC6");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.RepresentantesNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Representantes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Representantes");
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.Idgrado)
                    .HasName("PK__grado__3213E83FF364EF56");

                entity.Property(e => e.Grado1).IsUnicode(false);
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.Idhorario)
                    .HasName("PK__horario__3213E83F1D11E74A");

                entity.Property(e => e.Diasemana).IsUnicode(false);

                entity.Property(e => e.HoraFin).IsUnicode(false);

                entity.Property(e => e.Horainicio).IsUnicode(false);
            });

            modelBuilder.Entity<InscripcionEstudiante>(entity =>
            {
                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Estudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inscripcionEstudiante_Estudiantes");

                entity.HasOne(d => d.GradoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Grado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inscripcionEstudiante_grado");

                entity.HasOne(d => d.PeriodoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inscripcionEstudiante_periodo");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.Idmateria)
                    .HasName("PK__Materia__3213E83F04DFBD50");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Estudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_Estudiantes");

                entity.HasOne(d => d.GradoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Grado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_grado");

                entity.HasOne(d => d.PeriodoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.Periodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_periodo");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.Idperiodo)
                    .HasName("PK__perido__3213E83F066BBF41");

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__profesor__3213E83F6862E79A");

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Celular).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Representante>(entity =>
            {
                entity.Property(e => e.Apellidomadre).IsUnicode(false);

                entity.Property(e => e.Apellidopadre).IsUnicode(false);

                entity.Property(e => e.Celular).IsUnicode(false);

                entity.Property(e => e.Nombremadre).IsUnicode(false);

                entity.Property(e => e.Nombrepadre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

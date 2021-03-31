using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Calificaciones = new HashSet<Calificacione>();
            Clasealumnos = new HashSet<Clasealumno>();
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        [Column("idEstudiante")]
        public int IdEstudiante { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fechanacimiento { get; set; }
        public int Representantes { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
        [Column("fechaingreso", TypeName = "date")]
        public DateTime Fechaingreso { get; set; }
        [Column("fechaegreso", TypeName = "date")]
        public DateTime? Fechaegreso { get; set; }

        [ForeignKey(nameof(Representantes))]
        [InverseProperty(nameof(Representante.Estudiantes))]
        public virtual Representante RepresentantesNavigation { get; set; }
        [InverseProperty(nameof(Calificacione.EstudianteNavigation))]
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        [InverseProperty(nameof(Clasealumno.EstudianteNavigation))]
        public virtual ICollection<Clasealumno> Clasealumnos { get; set; }
        [InverseProperty(nameof(Matricula.EstudianteNavigation))]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Clase")]
    public partial class Clase
    {
        public Clase()
        {
            Clasealumnos = new HashSet<Clasealumno>();
        }

        [Key]
        [Column("idclase")]
        public int Idclase { get; set; }
        public int Grado { get; set; }
        [StringLength(10)]
        public string Materia { get; set; }
        public int Periodo { get; set; }
        [Column("profesor")]
        public int Profesor { get; set; }
        public int Horario { get; set; }

        [ForeignKey(nameof(Grado))]
        [InverseProperty("Clases")]
        public virtual Grado GradoNavigation { get; set; }
        [ForeignKey(nameof(Horario))]
        [InverseProperty("Clases")]
        public virtual Horario HorarioNavigation { get; set; }
        [ForeignKey(nameof(Periodo))]
        [InverseProperty("Clases")]
        public virtual Periodo Periodo1 { get; set; }
        [ForeignKey(nameof(Periodo))]
        [InverseProperty(nameof(Materium.Clases))]
        public virtual Materium PeriodoNavigation { get; set; }
        [ForeignKey(nameof(Profesor))]
        [InverseProperty("Clases")]
        public virtual Profesor ProfesorNavigation { get; set; }
        [InverseProperty(nameof(Clasealumno.ClaseNavigation))]
        public virtual ICollection<Clasealumno> Clasealumnos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Calificacione
    {
        [Key]
        [Column("idcalificacion")]
        public int Idcalificacion { get; set; }
        public int Estudiante { get; set; }
        public int Periodo { get; set; }
        public int Materia { get; set; }
        public int Notas { get; set; }
        public int Grado { get; set; }

        [ForeignKey(nameof(Estudiante))]
        [InverseProperty("Calificaciones")]
        public virtual Estudiante EstudianteNavigation { get; set; }
        [ForeignKey(nameof(Grado))]
        [InverseProperty("Calificaciones")]
        public virtual Grado GradoNavigation { get; set; }
        [ForeignKey(nameof(Materia))]
        [InverseProperty(nameof(Materium.Calificaciones))]
        public virtual Materium MateriaNavigation { get; set; }
        [ForeignKey(nameof(Notas))]
        [InverseProperty(nameof(Notum.Calificaciones))]
        public virtual Notum NotasNavigation { get; set; }
        [ForeignKey(nameof(Periodo))]
        [InverseProperty("Calificaciones")]
        public virtual Periodo PeriodoNavigation { get; set; }
    }
}

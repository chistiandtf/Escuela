using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Matricula")]
    public partial class Matricula
    {
        [Key]
        [Column("idmatricula")]
        public int Idmatricula { get; set; }
        public int Grado { get; set; }
        public int Periodo { get; set; }
        public int Estudiante { get; set; }

        [ForeignKey(nameof(Estudiante))]
        [InverseProperty("Matriculas")]
        public virtual Estudiante EstudianteNavigation { get; set; }
        [ForeignKey(nameof(Grado))]
        [InverseProperty("Matriculas")]
        public virtual Grado GradoNavigation { get; set; }
        [ForeignKey(nameof(Periodo))]
        [InverseProperty("Matriculas")]
        public virtual Periodo PeriodoNavigation { get; set; }
    }
}

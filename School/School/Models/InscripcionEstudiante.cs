using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Keyless]
    [Table("InscripcionEstudiante")]
    public partial class InscripcionEstudiante
    {
        [Column("idinscripcion")]
        public int Idinscripcion { get; set; }
        public int Grado { get; set; }
        public int Periodo { get; set; }
        public int Estudiante { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(Estudiante))]
        public virtual Estudiante EstudianteNavigation { get; set; }
        [ForeignKey(nameof(Grado))]
        public virtual Grado GradoNavigation { get; set; }
        [ForeignKey(nameof(Periodo))]
        public virtual Periodo PeriodoNavigation { get; set; }
    }
}

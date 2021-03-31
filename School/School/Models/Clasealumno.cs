using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Clasealumno")]
    public partial class Clasealumno
    {
        [Key]
        [Column("idEstudiante")]
        public int IdEstudiante { get; set; }
        public int Estudiante { get; set; }
        public int Clase { get; set; }

        [ForeignKey(nameof(Clase))]
        [InverseProperty("Clasealumnos")]
        public virtual Clase ClaseNavigation { get; set; }
        [ForeignKey(nameof(Estudiante))]
        [InverseProperty("Clasealumnos")]
        public virtual Estudiante EstudianteNavigation { get; set; }
    }
}

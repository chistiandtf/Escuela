using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Periodo")]
    public partial class Periodo
    {
        public Periodo()
        {
            Calificaciones = new HashSet<Calificacione>();
            Clases = new HashSet<Clase>();
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        public int Idperiodo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [InverseProperty(nameof(Calificacione.PeriodoNavigation))]
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        [InverseProperty(nameof(Clase.Periodo1))]
        public virtual ICollection<Clase> Clases { get; set; }
        [InverseProperty(nameof(Matricula.PeriodoNavigation))]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}

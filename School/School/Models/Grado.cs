using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Grado")]
    public partial class Grado
    {
        public Grado()
        {
            Calificaciones = new HashSet<Calificacione>();
            Clases = new HashSet<Clase>();
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        [Column("idgrado")]
        public int Idgrado { get; set; }
        [Required]
        [Column("Grado")]
        [StringLength(50)]
        public string Grado1 { get; set; }

        [InverseProperty(nameof(Calificacione.GradoNavigation))]
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        [InverseProperty(nameof(Clase.GradoNavigation))]
        public virtual ICollection<Clase> Clases { get; set; }
        [InverseProperty(nameof(Matricula.GradoNavigation))]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{

   
    public partial class Materium
    {
        public Materium()
        {
            Calificaciones = new HashSet<Calificacione>();
            Clases = new HashSet<Clase>();
        }

        [Key]
        [Column("idmateria")]
        public int Idmateria { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Calificacione.MateriaNavigation))]
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        [InverseProperty(nameof(Clase.PeriodoNavigation))]
        public virtual ICollection<Clase> Clases { get; set; }
    }
}

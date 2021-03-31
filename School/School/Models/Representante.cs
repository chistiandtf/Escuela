using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Representante
    {
        public Representante()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombremadre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidomadre { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombrepadre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidopadre { get; set; }
        [StringLength(50)]
        public string Celular { get; set; }
        [Column("telefono")]
        [StringLength(50)]
        public string Telefono { get; set; }

        [InverseProperty(nameof(Estudiante.RepresentantesNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}

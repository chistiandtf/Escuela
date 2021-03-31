using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("horario")]
    public partial class Horario
    {
        public Horario()
        {
            Clases = new HashSet<Clase>();
        }

        [Key]
        [Column("idhorario")]
        public int Idhorario { get; set; }
        [Required]
        [StringLength(50)]
        public string Diasemana { get; set; }
        [Required]
        [StringLength(50)]
        public string Horainicio { get; set; }
        [Required]
        [StringLength(50)]
        public string HoraFin { get; set; }

        [InverseProperty(nameof(Clase.HorarioNavigation))]
        public virtual ICollection<Clase> Clases { get; set; }
    }
}

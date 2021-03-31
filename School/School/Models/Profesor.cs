using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Profesor")]
    public partial class Profesor
    {
        public Profesor()
        {
            Clases = new HashSet<Clase>();
        }

        [Key]
        [Column("idProfesor")]
        public int IdProfesor { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fechanacimiento { get; set; }
        [StringLength(50)]
        public string Celular { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fechaingreso { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Fechaegreso { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [InverseProperty(nameof(Clase.ProfesorNavigation))]
        public virtual ICollection<Clase> Clases { get; set; }
    }
}

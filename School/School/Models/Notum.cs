using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Notum
    {
        public Notum()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        [Key]
        [Column("idnota")]
        public int Idnota { get; set; }
        [Column("nota1", TypeName = "decimal(4, 2)")]
        public decimal Nota1 { get; set; }
        [Column("nota2", TypeName = "decimal(4, 2)")]
        public decimal Nota2 { get; set; }
        [Column("nota3", TypeName = "decimal(4, 2)")]
        public decimal Nota3 { get; set; }
        [Column("notafinal", TypeName = "decimal(4, 2)")]
        public decimal Notafinal { get; set; }

        [InverseProperty(nameof(Calificacione.NotasNavigation))]
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}

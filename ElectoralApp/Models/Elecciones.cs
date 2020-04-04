using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectoralApp.Models
{
    public partial class Elecciones
    {
        public Elecciones()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Fecha de Realizacion")]
        [Required]
        public DateTime FechaDeRealización { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

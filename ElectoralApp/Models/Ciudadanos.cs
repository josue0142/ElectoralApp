using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectoralApp.Models
{
    public partial class Ciudadanos
    {
        public Ciudadanos()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Documento de Identidad")]
        public string DocumentoDeIdentidad { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Email { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectoralApp.Models
{
    public partial class PuestoElectivo
    {
        public PuestoElectivo()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripción { get; set; }

        [Required]
        public bool Estado { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}

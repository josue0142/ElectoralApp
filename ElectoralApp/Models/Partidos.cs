using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectoralApp.Models
{
    public partial class Partidos
    {
        public Partidos()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripción { get; set; }

        public string LogoDelPartido { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}

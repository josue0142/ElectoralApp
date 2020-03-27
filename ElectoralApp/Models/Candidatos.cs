using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectoralApp.Models
{
    public partial class Candidatos
    {
        public Candidatos()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Partido")]
        public int? PartidoFk { get; set; }

        [Required]
        [Display(Name = "Puesto Electivo")]
        public int? PuestoFk { get; set; }

        public string FotoDePerfil { get; set; }
        public bool Estado { get; set; }

        [Display(Name = "Partido")]
        public virtual Partidos PartidoFkNavigation { get; set; }

        [Display(Name = "Puesto Electivo")]
        public virtual PuestoElectivo PuestoFkNavigation { get; set; }
        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

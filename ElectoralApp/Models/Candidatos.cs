using System;
using System.Collections.Generic;

namespace ElectoralApp.Models
{
    public partial class Candidatos
    {
        public Candidatos()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? PartidoFk { get; set; }
        public int? PuestoFk { get; set; }
        public string FotoDePerfil { get; set; }
        public bool Estado { get; set; }

        public virtual Partidos PartidoFkNavigation { get; set; }
        public virtual PuestoElectivo PuestoFkNavigation { get; set; }
        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

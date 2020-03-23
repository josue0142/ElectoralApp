using System;
using System.Collections.Generic;

namespace ElectoralApp.Models
{
    public partial class PuestoElectivo
    {
        public PuestoElectivo()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ElectoralApp.Models
{
    public partial class Partidos
    {
        public Partidos()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string LogoDelPartido { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}

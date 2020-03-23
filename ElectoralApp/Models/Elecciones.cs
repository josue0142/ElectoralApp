using System;
using System.Collections.Generic;

namespace ElectoralApp.Models
{
    public partial class Elecciones
    {
        public Elecciones()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaDeRealización { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

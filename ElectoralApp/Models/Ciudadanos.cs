using System;
using System.Collections.Generic;

namespace ElectoralApp.Models
{
    public partial class Ciudadanos
    {
        public Ciudadanos()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }
        public string DocumentoDeIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

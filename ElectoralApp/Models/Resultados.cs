using System;
using System.Collections.Generic;

namespace ElectoralApp.Models
{
    public partial class Resultados
    {
        public int Id { get; set; }
        public int EleccionesFk { get; set; }
        public int CandidatosFk { get; set; }
        public int CiudadanosFk { get; set; }

        public virtual Candidatos CandidatosFkNavigation { get; set; }
        public virtual Ciudadanos CiudadanosFkNavigation { get; set; }
        public virtual Elecciones EleccionesFkNavigation { get; set; }
    }
}

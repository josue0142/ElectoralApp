using ElectoralApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralApp.DTO
{
    public class CiudadanosDTO
    {
        public CiudadanosDTO()
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

        [Required]
        public bool Estado { get; set; }

        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

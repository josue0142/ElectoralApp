using ElectoralApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralApp.DTO
{
    public class PartidosDTO
    {
        public PartidosDTO()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripción { get; set; }

        [Display(Name = "Logo del Partido")]
        public IFormFile LogoDelPartido { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}

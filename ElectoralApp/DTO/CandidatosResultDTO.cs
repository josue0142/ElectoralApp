﻿using ElectoralApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralApp.DTO
{
    public class CandidatosResultDTO
    {
        public CandidatosResultDTO()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Para crear un Candidato debe " +
            "existir al menos un partido creado y activo")]
        [Display(Name = "Partido")]
        public int? PartidoFk { get; set; }

        [Required(ErrorMessage = "Para crear un Candidato debe " +
            "existir al menos un puesto creado y activo")]
        [Display(Name = "Puesto Electivo")]
        public int? PuestoFk { get; set; }

        [Display(Name = "Foto del Candidato")]
        public string FotoDePerfil { get; set; }
        public bool Estado { get; set; }

        public int CantidadVotos { get; set; }

        [Display(Name = "Partido")]
        public virtual Partidos PartidoFkNavigation { get; set; }

        [Display(Name = "Puesto Electivo")]
        public virtual PuestoElectivo PuestoFkNavigation { get; set; }
        public virtual ICollection<Resultados> Resultados { get; set; }
    }
}

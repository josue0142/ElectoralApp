using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectoralApp.Models;
using Microsoft.AspNetCore.Http;
using ElectoralApp.Helpers;
using ElectoralApp.DTO;

namespace ElectoralApp.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly BDelectoralContext _context;

        public ResultadosController(BDelectoralContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            HttpContext.Session.SetInt32(Configuration.KeyIdEleccion, id);

            var query = (from re in _context.Resultados
                         join c in _context.Candidatos
                         on re.CandidatosFk equals c.Id
                         join pl in _context.PuestoElectivo
                         on c.PuestoFk equals pl.Id
                         where re.EleccionesFk == id
                         select pl.Id
                        ).Distinct().ToList();


            List<PuestoElectivo> puestoElectivos = new List<PuestoElectivo>();

            foreach (var item in query)
            {
                puestoElectivos.Add(_context.PuestoElectivo.Find(item));
            }

            return View(puestoElectivos);
        }

        [HttpGet]
        public IActionResult GenerateResults(int id)
        {
            var idEleccion = HttpContext.Session.GetInt32(Configuration.KeyIdEleccion);

            ViewBag.idEleccion = idEleccion;

            var context = (from re in _context.Resultados
                           join ca in _context.Candidatos
                           on re.CandidatosFk equals ca.Id
                           join pl in _context.PuestoElectivo 
                           on ca.PuestoFk equals pl.Id 
                           where re.EleccionesFk == idEleccion &&
                           pl.Id == id
                           select new Candidatos
                           {   
                               Id = ca.Id,
                               Nombre = ca.Nombre,
                               Apellido = ca.Apellido,
                               PartidoFkNavigation = ca.PartidoFkNavigation,
                               FotoDePerfil = ca.FotoDePerfil,

                           }
                           ).Distinct();

            var listCandidatosFull = (from re in _context.Resultados
                           join ca in _context.Candidatos
                           on re.CandidatosFk equals ca.Id
                           join pl in _context.PuestoElectivo
                           on ca.PuestoFk equals pl.Id
                           where re.EleccionesFk == idEleccion &&
                           pl.Id == id
                           select new Candidatos
                           {
                               Id = ca.Id,
                               Nombre = ca.Nombre,
                               Apellido = ca.Apellido,
                               PartidoFkNavigation = ca.PartidoFkNavigation,
                               FotoDePerfil = ca.FotoDePerfil,

                           }
                       ).ToList();

            ViewBag.List = listCandidatosFull;

            return View(context);
        }
    }
}

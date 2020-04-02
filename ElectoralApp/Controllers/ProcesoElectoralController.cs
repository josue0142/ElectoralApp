using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectoralApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectoralApp.Controllers
{
    public class ProcesoElectoralController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly BDelectoralContext _context;

        public ProcesoElectoralController(SignInManager<IdentityUser> signInManager, BDelectoralContext context)
        {
            this.signInManager = signInManager;
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

            return View();
        }

        [HttpPost]
        public IActionResult Index(Ciudadanos model)
        {
            #region validation for Ciudadano

            var ciudadano = _context.Ciudadanos
                .Where(a => a.DocumentoDeIdentidad == model.DocumentoDeIdentidad)
                .FirstOrDefault();

            if (ciudadano == null)
            {
                ModelState.AddModelError("", "La cedula ingresada no existe");
                return View(model);
            }

            if (ciudadano.Estado == false)
            {
                ModelState.AddModelError("", "Este ciudadano se encuentra inactivo");
            }

            #endregion

            #region validation for eleccion

            if (!_context.Elecciones.Where(a => a.Estado == true).Any())
            {
                ModelState.AddModelError("", "No hay ningun Proceso Electoral Activo");
            }
            else
            {
                return RedirectToAction("SelectPuestoElectivo", "ProcesoElectoral");
            }

            #endregion

            /*var eleccionEnCurso = _context
                .Elecciones
                .Where(a => a.Estado == true).FirstOrDefault();*/



            /*if ((eleccionEnCurso != null))
            {
                return RedirectToAction();
            }*/

            return View(model);
        }

        [HttpGet]
        public IActionResult SelectPuestoElectivo()
        {
            return View(_context.PuestoElectivo
                .Where(a => a.Estado == true)
                .ToList());
        }

        [HttpGet]
        public IActionResult SelectCandidato(int id)
        {
            var candidatos = _context.Candidatos
                .Where(a => a.PuestoFkNavigation.Id == id)
                .Include(a=> a.PartidoFkNavigation)
                .ToList();

            var puestoElectivo = _context.PuestoElectivo
                .Where(a => a.Id == id)
                .FirstOrDefault();

            ViewBag.PuestoElectivoName = puestoElectivo.Nombre;

            return View(candidatos);
        }

        [HttpGet]
        public IActionResult SelectCandidatoConfirm(int id)
        {
            var candidato = _context.Candidatos
                .Where(a => a.Id == id).Include(a=> a.PuestoFkNavigation)
                .FirstOrDefault();

            ViewBag.PuestoElectivoName = candidato.PuestoFkNavigation.Nombre;

            return View(candidato);
        }

        [HttpPost]
        public IActionResult ProcessVoting(int id)
        {
           return RedirectToAction("SelectPuestoElectivo","ProcesoElectoral");
        }
    }
}
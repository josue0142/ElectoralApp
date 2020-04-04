using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectoralApp.Helpers;
using ElectoralApp.Mail;
using ElectoralApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectoralApp.Controllers
{
    public class ProcesoElectoralController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly BDelectoralContext _context;
        private readonly IEmailSender _emailSender;

        public ProcesoElectoralController(SignInManager<IdentityUser> signInManager, BDelectoralContext context, IEmailSender emailSender)
        {
            this.signInManager = signInManager;
            this._context = context;
            this._emailSender = emailSender;
        }


        [HttpGet]
        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

            HttpContext.Session.Clear();

            return View();
        }

        [HttpPost]
        public IActionResult Index(Ciudadanos model)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

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
            else if (_context.Resultados
                .Where(a=>a.CiudadanosFk == ciudadano.Id && a.EleccionesFkNavigation.Estado == true).Any())
            {
                ModelState.AddModelError("", "El ciudadano ya ah ejercido su derecho al voto");
            }
            else
            {

                var eleccion = _context.Elecciones
                    .Where(a => a.Estado == true)
                    .FirstOrDefault();

                HttpContext.Session.SetInt32(Configuration.KeyIdEleccion,
                    eleccion.Id);

                HttpContext.Session.SetInt32(Configuration.KeyIdCiudadano,
                    ciudadano.Id);
                 

                return RedirectToAction("SelectPuestoElectivo", "ProcesoElectoral");
            }

            #endregion

            return View(model);
        }

        [HttpGet]
        public IActionResult SelectPuestoElectivo()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

            ViewBag.PuestoVotado = "" + HttpContext.Session.GetString(Configuration.KeyNamePuestoElectivo);

            return View(_context.PuestoElectivo
                .Where(a => a.Estado == true && a.Nombre != "Ninguno")
                .ToList());
        }

        [HttpGet]
        public IActionResult SelectCandidato(int id)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

            var candidatos = _context.Candidatos
                .Where(a => a.PuestoFkNavigation.Id == id)
                .Include(a => a.PartidoFkNavigation)
                .ToList();

            candidatos.Add(_context.Candidatos.
                Where(a => a.Nombre == "Ninguno")
                .FirstOrDefault());

            var puestoElectivo = _context.PuestoElectivo
                .Where(a => a.Id == id)
                .FirstOrDefault();

            string puesto = HttpContext.Session.GetString(Configuration.KeyNamePuestoElectivo);
            puesto = puesto + puestoElectivo.Nombre;
            HttpContext.Session.SetString(Configuration.KeyNamePuestoElectivo, puesto);

            ViewBag.PuestoElectivoName = puestoElectivo.Nombre;

            return View(candidatos);
        }

        [HttpGet]
        public IActionResult SelectCandidatoConfirm(int id)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

            var candidato = _context.Candidatos
                .Where(a => a.Id == id).Include(a => a.PuestoFkNavigation)
                .FirstOrDefault();

            ViewBag.PuestoElectivoName = candidato.PuestoFkNavigation.Nombre;

            return View(candidato);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProcessVoting(int id)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");

            try
            {
                Resultados resultado = new Resultados();

                resultado.CandidatosFk = id;

                resultado.CiudadanosFk = Convert.ToInt32(
                    HttpContext.Session.GetInt32(Configuration.KeyIdCiudadano));

                resultado.EleccionesFk = Convert.ToInt32(
                    HttpContext.Session.GetInt32(Configuration.KeyIdEleccion));



                var candidato = await _context.Candidatos
                    .Where(a=>a.Id==id)
                    .Include(a=>a.PuestoFkNavigation).FirstOrDefaultAsync();

                string message = HttpContext.Session.GetString(Configuration.KeyMessage);
                message = message + candidato.Nombre 
                    + " " + candidato.Apellido + " Para el puesto de " +
                    candidato.PuestoFkNavigation.Nombre + ". ";

                HttpContext.Session.SetString(Configuration.KeyMessage, message);


                await _context.Resultados.AddAsync(resultado);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
           
           return RedirectToAction("SelectPuestoElectivo","ProcesoElectoral");
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            int idCiudadano = Convert.ToInt32(HttpContext.Session.GetInt32(Configuration.KeyIdCiudadano));

            var to =  await _context.Ciudadanos.FindAsync(idCiudadano);

            string vmessage = HttpContext.Session.GetString(Configuration.KeyMessage);

            var message = new Message(new string[] { to.Email }, "Votacion", "Gracias por " +
                "utilizar nuestros servicios, sus votos fueron: " + vmessage);

            await _emailSender.SendEmailAsync(message);

            return RedirectToAction("Index");
        }
    }
}
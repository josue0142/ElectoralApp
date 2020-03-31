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
            var ciudadano = _context.Ciudadanos
                .Where(a => a.DocumentoDeIdentidad == model.DocumentoDeIdentidad)
                .FirstOrDefault();

            if (ciudadano == null)
            {
                ModelState.AddModelError("", "La cedula ingresada no existe");
                return View(model);
            }

            if (!_context.Elecciones.Where(a => a.Estado == true).Any())
            {
                ModelState.AddModelError("", "No hay ningun Proceso Electoral Activo");
            }

            if (ciudadano.Estado == false)
            {
                ModelState.AddModelError("", "Este ciudadano se encuentra inactivo");
            }

            var eleccionEnCurso = _context
                .Elecciones
                .Where(a => a.Estado == true).FirstOrDefault();


            //if((eleccionEnCurso != null) && )

            /*var query = _context.Ciudadanos.FromSql(@"select c.Id from Ciudadanos as c
                                            inner join Resultados
                                            on Resultados.Ciudadanos_FK = c.Id
                                            inner join Elecciones as e
                                            on Resultados.Elecciones_FK = e.Id
                                            where e.Estado = 'true'");*/



            return View(model);
        }
    }
}
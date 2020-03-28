using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectoralApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ElectoralApp.Controllers
{
    [Authorize]
    public class EleccionesController : Controller
    {
        private readonly BDelectoralContext _context;

        public EleccionesController(BDelectoralContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(_context.Elecciones.Where(a => a.Estado == true).Count() != 0)
            {
                ViewBag.BtnIniciarPElectivo = false;
            }
            else
            {
                ViewBag.BtnIniciarPElectivo = true;
            }

            return View(await _context.Elecciones.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elecciones = await _context.Elecciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elecciones == null)
            {
                return NotFound();
            }

            return View(elecciones);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Elecciones elecciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elecciones);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(elecciones);
        }

        [HttpGet]
        public async Task<IActionResult> Start(int id)
        {
            var elecciones = await _context.Elecciones.FindAsync(id);

            elecciones.Estado = true;
            _context.Update(elecciones);
            await  _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Stop(int id)
        {
            var elecciones = await _context.Elecciones.FindAsync(id);

            elecciones.Estado = false;
            _context.Update(elecciones);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

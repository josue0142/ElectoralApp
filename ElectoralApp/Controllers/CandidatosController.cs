using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectoralApp.Models;

namespace ElectoralApp.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly BDelectoralContext _context;

        public CandidatosController(BDelectoralContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bDelectoralContext = _context.Candidatos.Include(c => c.PartidoFkNavigation).Include(c => c.PuestoFkNavigation);
            return View(await bDelectoralContext.ToListAsync());
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            ViewData["PartidoFk"] = new SelectList(_context.Partidos, "Id", "Nombre");
            ViewData["PuestoFk"] = new SelectList(_context.PuestoElectivo, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Candidatos candidatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatos);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewData["PartidoFk"] = new SelectList(_context.Partidos, "Id", "Nombre", candidatos.PartidoFk);
            ViewData["PuestoFk"] = new SelectList(_context.PuestoElectivo, "Id", "Nombre", candidatos.PuestoFk);

            return View(candidatos);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos.FindAsync(id);

            if (candidatos == null)
            {
                return NotFound();
            }

            ViewData["PartidoFk"] = new SelectList(_context.Partidos, "Id", "Nombre", candidatos.PartidoFk);
            ViewData["PuestoFk"] = new SelectList(_context.PuestoElectivo, "Id", "Nombre", candidatos.PuestoFk);

            return View(candidatos);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id,Candidatos candidatos)
        {
            if (id != candidatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {                  
                    return NotFound();                
                }

                return RedirectToAction("Index");
            }

            ViewData["PartidoFk"] = new SelectList(_context.Partidos, "Id", "Nombre", candidatos.PartidoFk);
            ViewData["PuestoFk"] = new SelectList(_context.PuestoElectivo, "Id", "Nombre", candidatos.PuestoFk);

            return View(candidatos);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .Include(c => c.PartidoFkNavigation)
                .Include(c => c.PuestoFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var candidatos = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidatos);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

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
    public class ResultadosController : Controller
    {
        private readonly BDelectoralContext _context;

        public ResultadosController(BDelectoralContext context)
        {
            _context = context;
        }

        // GET: Resultados
        public async Task<IActionResult> Index()
        {
            var bDelectoralContext = _context.Resultados.Include(r => r.CandidatosFkNavigation).Include(r => r.CiudadanosFkNavigation).Include(r => r.EleccionesFkNavigation);
            return View(await bDelectoralContext.ToListAsync());
        }

        // GET: Resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados
                .Include(r => r.CandidatosFkNavigation)
                .Include(r => r.CiudadanosFkNavigation)
                .Include(r => r.EleccionesFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultados == null)
            {
                return NotFound();
            }

            return View(resultados);
        }

        // GET: Resultados/Create
        public IActionResult Create()
        {
            ViewData["CandidatosFk"] = new SelectList(_context.Candidatos, "Id", "Apellido");
            ViewData["CiudadanosFk"] = new SelectList(_context.Ciudadanos, "Id", "Apellido");
            ViewData["EleccionesFk"] = new SelectList(_context.Elecciones, "Id", "Nombre");
            return View();
        }

        // POST: Resultados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EleccionesFk,CandidatosFk,CiudadanosFk")] Resultados resultados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatosFk"] = new SelectList(_context.Candidatos, "Id", "Apellido", resultados.CandidatosFk);
            ViewData["CiudadanosFk"] = new SelectList(_context.Ciudadanos, "Id", "Apellido", resultados.CiudadanosFk);
            ViewData["EleccionesFk"] = new SelectList(_context.Elecciones, "Id", "Nombre", resultados.EleccionesFk);
            return View(resultados);
        }

        // GET: Resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados.FindAsync(id);
            if (resultados == null)
            {
                return NotFound();
            }
            ViewData["CandidatosFk"] = new SelectList(_context.Candidatos, "Id", "Apellido", resultados.CandidatosFk);
            ViewData["CiudadanosFk"] = new SelectList(_context.Ciudadanos, "Id", "Apellido", resultados.CiudadanosFk);
            ViewData["EleccionesFk"] = new SelectList(_context.Elecciones, "Id", "Nombre", resultados.EleccionesFk);
            return View(resultados);
        }

        // POST: Resultados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EleccionesFk,CandidatosFk,CiudadanosFk")] Resultados resultados)
        {
            if (id != resultados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadosExists(resultados.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatosFk"] = new SelectList(_context.Candidatos, "Id", "Apellido", resultados.CandidatosFk);
            ViewData["CiudadanosFk"] = new SelectList(_context.Ciudadanos, "Id", "Apellido", resultados.CiudadanosFk);
            ViewData["EleccionesFk"] = new SelectList(_context.Elecciones, "Id", "Nombre", resultados.EleccionesFk);
            return View(resultados);
        }

        // GET: Resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados
                .Include(r => r.CandidatosFkNavigation)
                .Include(r => r.CiudadanosFkNavigation)
                .Include(r => r.EleccionesFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultados == null)
            {
                return NotFound();
            }

            return View(resultados);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultados = await _context.Resultados.FindAsync(id);
            _context.Resultados.Remove(resultados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadosExists(int id)
        {
            return _context.Resultados.Any(e => e.Id == id);
        }
    }
}

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
    public class PuestoElectivoController : Controller
    {
        private readonly BDelectoralContext _context;

        public PuestoElectivoController(BDelectoralContext context)
        {
            _context = context;
        }

        // GET: PuestoElectivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PuestoElectivo.ToListAsync());
        }

        // GET: PuestoElectivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivo = await _context.PuestoElectivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoElectivo == null)
            {
                return NotFound();
            }

            return View(puestoElectivo);
        }

        // GET: PuestoElectivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuestoElectivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripción,Estado")] PuestoElectivo puestoElectivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestoElectivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestoElectivo);
        }

        // GET: PuestoElectivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivo = await _context.PuestoElectivo.FindAsync(id);
            if (puestoElectivo == null)
            {
                return NotFound();
            }
            return View(puestoElectivo);
        }

        // POST: PuestoElectivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripción,Estado")] PuestoElectivo puestoElectivo)
        {
            if (id != puestoElectivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestoElectivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoElectivoExists(puestoElectivo.Id))
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
            return View(puestoElectivo);
        }

        // GET: PuestoElectivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivo = await _context.PuestoElectivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoElectivo == null)
            {
                return NotFound();
            }

            return View(puestoElectivo);
        }

        // POST: PuestoElectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestoElectivo = await _context.PuestoElectivo.FindAsync(id);
            _context.PuestoElectivo.Remove(puestoElectivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoElectivoExists(int id)
        {
            return _context.PuestoElectivo.Any(e => e.Id == id);
        }
    }
}

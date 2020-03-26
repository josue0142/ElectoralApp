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
    public class PuestoElectivoController : Controller
    {
        private readonly BDelectoralContext _context;

        public PuestoElectivoController(BDelectoralContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View (_context.PuestoElectivo.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PuestoElectivo puestoElectivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestoElectivo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(puestoElectivo);
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Edit(int id,PuestoElectivo puestoElectivo)
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
                  
                }
                return RedirectToAction("Index");
            }
            return View(puestoElectivo);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivo = await _context.PuestoElectivo.FirstOrDefaultAsync(m => m.Id == id);
            if (puestoElectivo == null)
            {
                return NotFound();
            }

            return View(puestoElectivo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var puestoElectivo = await _context.PuestoElectivo.FindAsync(id);
            _context.PuestoElectivo.Remove(puestoElectivo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

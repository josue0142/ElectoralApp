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
    public class PartidosController : Controller
    {
        private readonly BDelectoralContext _context;

        public PartidosController(BDelectoralContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Partidos.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Partidos partidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partidos);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(partidos);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partidos = await _context.Partidos.FindAsync(id);

            if (partidos == null)
            {
                return NotFound();
            }

            return View(partidos);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Partidos partidos)
        {
            if (id != partidos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index");
            }

            return View(partidos);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partidos = await _context.Partidos.FirstOrDefaultAsync(m => m.Id == id);
            if (partidos == null)
            {
                return NotFound();
            }

            return View(partidos);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var partidos = await _context.Partidos.FindAsync(id);
            _context.Partidos.Remove(partidos);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

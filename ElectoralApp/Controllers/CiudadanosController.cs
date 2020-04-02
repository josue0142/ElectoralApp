using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectoralApp.Models;
using Microsoft.AspNetCore.Authorization;
using ElectoralApp.DTO;
using AutoMapper;

namespace ElectoralApp.Controllers
{
    [Authorize]
    public class CiudadanosController : Controller
    {
        private readonly BDelectoralContext _context;

        public CiudadanosController(BDelectoralContext context, IMapper mapper)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Ciudadanos.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ciudadanos ciudadanos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudadanos);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(ciudadanos);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadanos = await _context.Ciudadanos.FindAsync(id);
            if (ciudadanos == null)
            {
                return NotFound();
            }

            return View(ciudadanos);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ciudadanos ciudadanos)
        {
            if (id != ciudadanos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudadanos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index");
            }

            return View(ciudadanos);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Elecciones.Where(a => a.Estado == true).Any())
            {
                return RedirectToAction("Index");
            }

            var ciudadanos = await _context.Ciudadanos.FindAsync(id);

            if (ciudadanos.Estado == true)
            {
                ciudadanos.Estado = false;
            }
            else
            {
                ciudadanos.Estado = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectoralApp.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ElectoralApp.DTO;
using System.IO;

namespace ElectoralApp.Controllers
{
    [Authorize]
    public class PartidosController : Controller
    {
        private readonly BDelectoralContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _iHostingEnvironment;

        public PartidosController(BDelectoralContext context, IMapper mapper, IHostingEnvironment iHostingEnvironment)
        {
            _context = context;
            this._mapper = mapper;
            this._iHostingEnvironment = iHostingEnvironment;
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
        public async Task<IActionResult> Create(PartidosDTO partidosDTO)
        {
            var partido = new Partidos();

            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (partidosDTO.LogoDelPartido != null)
                {
                    var folderPath = Path.Combine(_iHostingEnvironment.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + partidosDTO.LogoDelPartido.FileName;
                    var filePath = Path.Combine(folderPath, uniqueName);

                    if (filePath != null) partidosDTO
                            .LogoDelPartido
                            .CopyTo(new FileStream(filePath, mode: FileMode.Create));
                }

                partido = _mapper.Map<Partidos>(partidosDTO);

                partido.LogoDelPartido = uniqueName;

                _context.Add(partido);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(partidosDTO);
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

            var partidosDTO = _mapper.Map<PartidosDTO>(partidos);
            return View(partidosDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PartidosDTO partidosDTO)
        {
            if (id != partidosDTO.Id)
            {
                return NotFound();
            }

            var partido = await _context.Partidos.FirstOrDefaultAsync(d => d.Id == partidosDTO.Id);

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueName = null;
                    if (partidosDTO.LogoDelPartido != null)
                    {
                        var folderPath = Path.Combine(_iHostingEnvironment.WebRootPath, "images");
                        uniqueName = Guid.NewGuid().ToString() + "_" + partidosDTO.LogoDelPartido.FileName;
                        var filePath = Path.Combine(folderPath, uniqueName);

                        if (!string.IsNullOrEmpty(partido.LogoDelPartido))
                        {
                            var filePathDelete = Path.Combine(folderPath, partido.LogoDelPartido);

                            if (System.IO.File.Exists(filePathDelete))
                            {
                                var fileInfo = new System.IO.FileInfo(filePathDelete);
                                fileInfo.Delete();
                            }
                        }

                        if (filePath != null) partidosDTO
                                .LogoDelPartido
                                .CopyTo(new FileStream(filePath, mode: FileMode.Create));
                    }

                    //Id, Nombre, Descripción, Logo_del_partido, Estado
                    partido.Nombre = partidosDTO.Nombre;
                    partido.Descripción = partidosDTO.Descripción;
                    partido.Estado = partidosDTO.Estado; 
                    partido.LogoDelPartido = uniqueName;

                    _context.Update(partido);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return View(partidosDTO);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectoralApp.Models;
using AutoMapper;
using ElectoralApp.DTO;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ElectoralApp.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly BDelectoralContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _iHostingEnvironment;

        public CandidatosController(BDelectoralContext context, IMapper mapper, IHostingEnvironment iHostingEnvironment)
        {
            _context = context;
            this._mapper = mapper;
            this._iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bDelectoralContext = _context.Candidatos.Include(c => c.PartidoFkNavigation).Include(c => c.PuestoFkNavigation);
            return View(await bDelectoralContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PartidoFk"] = new SelectList(
                _context
                .Partidos
                .Where(a=> a.Estado == true), "Id", "Nombre");

            ViewData["PuestoFk"] = new SelectList(
                _context
                .PuestoElectivo
                .Where(a => a.Estado == true), "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidatosDTO candidatosDTO)
        {
            var candidato = new Candidatos();

            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (candidatosDTO.FotoDePerfil != null)
                {
                    var folderPath = Path.Combine(_iHostingEnvironment.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + candidatosDTO.FotoDePerfil.FileName;
                    var filePath = Path.Combine(folderPath, uniqueName);

                    if (filePath != null) candidatosDTO
                            .FotoDePerfil
                            .CopyTo(new FileStream(filePath, mode: FileMode.Create));
                }

                candidato = _mapper.Map<Candidatos>(candidatosDTO);

                candidato.FotoDePerfil = uniqueName;

                _context.Add(candidato);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewData["PartidoFk"] = new SelectList(
                _context
                .Partidos
                .Where(a => a.Estado == true), "Id", "Nombre", candidatosDTO.PartidoFk);

            ViewData["PuestoFk"] = new SelectList(
                _context
                .PuestoElectivo
                .Where(a => a.Estado == true), "Id", "Nombre", candidatosDTO.PuestoFk);

            return View(candidatosDTO);
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

            ViewData["PartidoFk"] = new SelectList(
                _context
                .Partidos
                .Where(a => a.Estado == true), "Id", "Nombre", candidatos.PartidoFk);

            ViewData["PuestoFk"] = new SelectList(
                _context
                .PuestoElectivo
                .Where(a => a.Estado == true), "Id", "Nombre", candidatos.PuestoFk);

            var candidatoDTO = _mapper.Map<CandidatosDTO>(candidatos);
            return View(candidatoDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, CandidatosDTO candidatosDTO)
        {
            if (id != candidatosDTO.Id)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.FirstOrDefaultAsync(d => d.Id == candidatosDTO.Id);
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueName = null;
                    if (candidatosDTO.FotoDePerfil != null)
                    {
                        var folderPath = Path.Combine(_iHostingEnvironment.WebRootPath, "images");
                        uniqueName = Guid.NewGuid().ToString() + "_" + candidatosDTO.FotoDePerfil.FileName;
                        var filePath = Path.Combine(folderPath, uniqueName);
                     
                        if (!string.IsNullOrEmpty(candidato.FotoDePerfil))
                        {
                            var filePathDelete = Path.Combine(folderPath, candidato.FotoDePerfil);

                            if (System.IO.File.Exists(filePathDelete))
                            {
                                var fileInfo = new System.IO.FileInfo(filePathDelete);
                                fileInfo.Delete();
                            }
                        }

                        if (filePath != null)
                        {
                            candidatosDTO.FotoDePerfil
                                .CopyTo(new FileStream(filePath, mode: FileMode.Create));
                        }
                    }

                    candidato.Nombre = candidatosDTO.Nombre;
                    candidato.Apellido = candidatosDTO.Apellido;
                    candidato.PartidoFk = candidatosDTO.PartidoFk;
                    candidato.PuestoFk = candidatosDTO.PuestoFk;
                    candidato.Estado = candidatosDTO.Estado;
                    candidato.FotoDePerfil = uniqueName;

                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

            ViewData["PartidoFk"] = new SelectList(
                 _context
                 .Partidos
                 .Where(a => a.Estado == true), "Id", "Nombre", candidatosDTO.PartidoFk);

            ViewData["PuestoFk"] = new SelectList(
                _context
                .PuestoElectivo
                .Where(a => a.Estado == true), "Id", "Nombre", candidatosDTO.PuestoFk);

            return View(candidatosDTO);
        }

        [HttpGet]
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

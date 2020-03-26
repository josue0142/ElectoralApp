using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectoralApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            List<string> optionsList = new List<string> { 
                "Candidatos",
                "Partidos",
                "Puesto electivo",
                "Ciudadanos",
                "Elecciones" };

            ViewBag.OptionsList = optionsList;
            return View();
        }
    }
}
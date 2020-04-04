using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectoralApp.Controllers
{
    public class AdminOptions
    {
        public string Name { get; set; }
        public string NameController { get; set; }
    }

    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            List<AdminOptions> optionsList = new List<AdminOptions> {

                new AdminOptions{
                    Name = "Candidatos",
                    NameController = "Candidatos"
                },

                new AdminOptions{
                    Name = "Partidos",
                    NameController = "Partidos"
                },

                new AdminOptions{
                    Name = "Puesto electivo",
                    NameController = "PuestoElectivo"
                },
                
                new AdminOptions{
                    Name = "Ciudadanos",
                    NameController = "Ciudadanos"
                },
                       
                new AdminOptions{
                    Name = "Elecciones",
                    NameController = "Elecciones"
                }

            };

            ViewBag.OptionsList = optionsList;
            return View();
        }
    }
}
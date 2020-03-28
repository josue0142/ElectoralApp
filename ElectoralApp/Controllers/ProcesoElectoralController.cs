using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectoralApp.Controllers
{
    public class ProcesoElectoralController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public ProcesoElectoralController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index","Admin"); 

                return View();
        }

    }
}
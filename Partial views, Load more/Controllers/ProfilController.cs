using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Partial_views__Load_more.Models;
using Partial_views__Load_more.ViewModels.ProfilViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partial_views__Load_more.Controllers
{
    public class ProfilController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        public ProfilController(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Profil()
        {
            AppUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
        
            return View(user);
        }
    }
}

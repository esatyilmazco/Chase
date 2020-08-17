using System;
using System.Threading.Tasks;
using Chase.Entities.Tangible;
using Chase.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chase.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //Uygulama İlk Açıldığın'da Çıkan Sayfa'nın Methodu.ve giriş yap sayfasının Methodu.
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AppUserLoginViewModel loginViewModel)
        {
            if (loginViewModel.UserName == null || loginViewModel.Password==null)
            {
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password,
                    loginViewModel.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin", new {area = "Admin"});
                    }
                    else
                    {
                        return RedirectToAction("Index", "Member", new {area = "Member"});
                    }
                }
            }

            return View("Index", loginViewModel);
        }

        //Kayıt Ol Sayfasının Görünüm Methodu
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AppUserRegisterViewModel appUserAddViewModel)
        {
            if (appUserAddViewModel.Name==null)
            {
                return View();
            }
            AppUser user = new AppUser
            {
                UserName = appUserAddViewModel.UserName,
                Email = appUserAddViewModel.Email,
                Name = appUserAddViewModel.Name,
                SurName = appUserAddViewModel.SurName
            };
            var result = await _userManager.CreateAsync(user, appUserAddViewModel.Password);
            if (result.Succeeded)
            {
                var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                if (addRoleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(appUserAddViewModel);
        }


        public IActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index");
        }
    }
}
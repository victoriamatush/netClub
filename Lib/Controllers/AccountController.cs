using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Lib.Models;
using Lib.ViewModels;


namespace Kursova.Controllers
{
    
    public class AccountController : Controller
    {
       
        private LibContext libContext;

      
        public AccountController(LibContext context)
        {
            libContext = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = await libContext.Accounts.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (account != null)
                {
                    await Authenticate(model.Email); 
                    return RedirectToAction("Index", "Home");
                }
               
                ModelState.AddModelError("", "Некоректні пошта і/або пароль");
            }
            return View(model);
        }

    
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
    
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            
            if (ModelState.IsValid)
            {
                Account account = await libContext.Accounts.FirstOrDefaultAsync(u => u.Email == model.Email);
                bool is_manager=false;
                if (account == null)
                {
                    if(model.Is_manager_checked=="true")                    
                      is_manager = true; 
                    

                    libContext.Accounts.Add(new Account 
                    { Email = model.Email, Password = model.Password, 
                      Register_Date = DateTime.Now, Is_manager=is_manager});
                   
                    await libContext.SaveChangesAsync();
                    await Authenticate(model.Email); 

                    return RedirectToAction("Index", "Home");
                }
                else
               
                    ModelState.AddModelError("", "Некоректні пошта і/або пароль");
            }
            return View("Home");
        }

        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
         
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
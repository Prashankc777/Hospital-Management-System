using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagementSystemWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Account.ViewModel;

namespace HospitalManagementSystemWeb.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult>  Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var userE = await _userManager.FindByNameAsync(model.Username);
            var userM = await _userManager.FindByEmailAsync(model.Email);
            if (userE != null)
            {
                ViewBag.ErrorMessage = $"User with name {model.Username} already Exist..";
                return View("Error");
            }
            if (userM != null)
            {
                ViewBag.ErrorMessage = $"User with name {model.Email} already Exist..";
                return View("Error");
            }
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Username,
                Address = model.Address,
                Occupation = model.Occupation
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                 
                ModelState.AddModelError(string.Empty,  error.Description);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(string returnUrl, LoginViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var Result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (Result.Succeeded)
            {
                return RedirectToAction("Index", "Administration");
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(model);



        }




    }
}

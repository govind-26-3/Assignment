using System.Data;
using Clinic_Appointment_System.Constants;
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> manager, SignInManager<User> signInManager)
        {
            _userManager = manager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = new User { UserName = user.Email, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
                var result = await _userManager.CreateAsync(createdUser, user.Password);
                if (result.Succeeded)
                {
                    
                    await _userManager.AddToRoleAsync(createdUser, Role.Patient);
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(login.Email);
                    if (user != null)
                    {
                        
                        HttpContext.Session.SetString("UserId", user.Id.ToString());
                        Console.WriteLine("Session Set: " + HttpContext.Session.GetString("UserId"));
                    }
                    return RedirectToAction("GetAllAppointments", "Appointment");
                }
                ModelState.AddModelError("", "Login failed. Please check your email and password.");
            }
            return View(login);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}


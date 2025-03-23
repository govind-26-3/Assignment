using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Clinic_Appointment_System.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")] // Ensure only admins can access this controller
public class AdminController : Controller
{
     readonly UserManager<User> _userManager; // UserManager for managing users
     readonly RoleManager<IdentityRole> _roleManager; // RoleManager for managing roles

    public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: Admin Dashboard
    public IActionResult Index()
    {
        return View();
    }

    // GET: Manage Users
    public async Task<IActionResult> GetAllUsers()
    {
        var users = _userManager.Users; // Get all users
        return View(await users.ToListAsync());
    }

    //// GET: Create User
    //public IActionResult CreateUser()
    //{
    //    return View();
    //}

    //// POST: Create User
    //[HttpPost]
    //public async Task<IActionResult> CreateUser(User user, string password)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var result = await _userManager.CreateAsync(user, password);
    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction("Users");
    //        }
    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError(string.Empty, error.Description);
    //        }
    //    }
    //    return View(user);
    //}

    // GET: Edit User
    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: Edit User
    [HttpPost]
    public async Task<IActionResult> EditUser(User user)
    {
        if (ModelState.IsValid)
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("GetAllUsers");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(user);
    }

    // GET: Delete User
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: Delete User
    [HttpPost, ActionName("DeleteUser")]
    public async Task<IActionResult> DeleteUserConfirmed(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction("Users");
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Clinic_Appointment_System.Models;

using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")] 
public class AdminController : Controller
{
     readonly UserManager<User> _userManager; 
     readonly RoleManager<IdentityRole> _roleManager; 

    public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    
    public IActionResult Index()
    {
        return View();
    }

   
    public async Task<IActionResult> GetAllUsers()
    {
        var users = _userManager.Users; 
        return View(await users.ToListAsync());
    }

    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

   
    [HttpPost]
    public async Task<IActionResult> EditUser(User user)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

          
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;

            
            var result = await _userManager.UpdateAsync(existingUser);
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

 
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction("GetAllUsers");
    }
}
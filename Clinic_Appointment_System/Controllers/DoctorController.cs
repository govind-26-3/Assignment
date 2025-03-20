
using Clinic_Appointment_System.Models;

using Clinic_Appointment_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Controllers
{
    public class DoctorController : Controller
    {

        readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> GetAllDoctors()
        {
            return View(await _doctorService.GetAllDoctorsAsync());
        }

        public async Task<IActionResult> AddDoctor()
        {
            //var doctor = await _doctorService.GetDoctorByIdAsync(id);
            //return View(doctor);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            ModelState.Remove("Appointments");
            if (ModelState.IsValid)
            {
                await _doctorService.AddDoctorAsync(doctor);
                return RedirectToAction("GetAllDoctors");
            }
            return View(doctor);
        }

        public async Task<IActionResult> UpdateDoctor(int id)
        {

            return View(await _doctorService.GetDoctorByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            ModelState.Remove("Appointments");
            if (ModelState.IsValid)
            {
                await _doctorService.UpdateDoctorAsync(doctor);
                return RedirectToAction("GetAllDoctors");
            }
            return View(doctor);
        }
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            return View(doctor);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(Doctor doctor)
        {
            await _doctorService.DeleteDoctorAsync(doctor.DoctorId);
            return RedirectToAction("GetAllDoctors");
        }
    }
}

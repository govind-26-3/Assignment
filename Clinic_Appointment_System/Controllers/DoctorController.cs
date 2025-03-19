using Clinic_Appointment_System.Exceptions;
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Controllers
{
    public class DoctorController : Controller
    {

        readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IActionResult> GetAllDoctors()
        {
            return View(await _doctorRepository.GetAllDoctorsAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException(id);
            }
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorRepository.AddDoctorAsync(doctor);
                return RedirectToAction("GetAllDoctors");
            }
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorRepository.UpdateDoctorAsync(doctor);
                return RedirectToAction("GetAllDoctors");
            }
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctorById(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return RedirectToAction("GetAllDoctors");
        }
    }
}

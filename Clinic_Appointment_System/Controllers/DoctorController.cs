
using Clinic_Appointment_System.Models;

using Clinic_Appointment_System.Services;
using Clinic_Appointment_System.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddDoctor()
        {
           
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

        public async Task<IActionResult> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _doctorService.GetAllAppointmentsByDoctorIdAsync(id);
            var appointmentViewModels = appointments.Select(a => new AppointmentViewModel
            {
                AppointmentId = a.AppointmentId,
                PatientName = a.Patient.FirstName + " " + a.Patient.LastName, 
                AppointmentDate = a.AppointmentDate,
                Status = a.Status.ToString(),
            }).ToList();

            return View(appointmentViewModels); 
        }
        
    }
}

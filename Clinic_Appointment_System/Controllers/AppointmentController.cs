
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Services;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic_Appointment_System.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        readonly IAppointmentService _appointmentService;
        readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }


        public async Task<IActionResult> GetAllAppointments()
        {

            var patientId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(patientId))
            {
                return RedirectToAction("Login", "Account");
            }

            var appointments = await _appointmentService.GetAllAppointmentsAsync(patientId);
            return View(appointments);

        }




        public async Task<IActionResult> GetAppointment(int id)
        {

            return View(await _appointmentService.GetAppointmentByIdAsync(id));
        }


        public async Task<IActionResult> AddAppointment()
        {

            ViewData["DoctorId"] = new SelectList(await _doctorService.GetAllDoctorsAsync(), "DoctorId", "Name");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment(Appointment appointment)
        {
            var patientId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(patientId))
            {
                return RedirectToAction("Login", "Account");
            }
            appointment.PatientId = patientId;
            if (appointment.AppointmentDate <= DateTime.Now)
            {
                ModelState.AddModelError("AppointmentDate", "The appointment date must be in the future.");
                ViewData["DoctorId"] = new SelectList(await _doctorService.GetAllDoctorsAsync(), "DoctorId", "Name");
                return View(appointment);
            }
            await _appointmentService.AddAppointmentAsync(appointment);
            return RedirectToAction("GetAllAppointments");

        }
        public async Task<IActionResult> EditAppointmentStatus(int id)
        {
            return View(await _appointmentService.GetAppointmentByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditAppointmentStatus(int id, string status)
        {
            await _appointmentService.UpdateAppointmentStatusAsync(id, status);
            return RedirectToAction("GetAllAppointments");
        }


        [HttpGet]
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);


            return RedirectToAction("GetAllAppointments");
        }

    }
}

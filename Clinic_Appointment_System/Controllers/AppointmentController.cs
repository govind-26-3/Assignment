using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic_Appointment_System.Controllers
{
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
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return View(appointments); 
        }
        [HttpPost]
        public async Task<IActionResult> GetAllAppointments(int userId)
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync(userId);
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
            await _appointmentService.AddAppointmentAsync(appointment);
            return RedirectToAction("GetAllAppointments");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string status)
        {
            await _appointmentService.UpdateAppointmentStatusAsync(id, status);
            return RedirectToAction("GetAllAppointments");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction("GetAllAppointments");
        }


    }
}

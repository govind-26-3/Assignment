using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Controllers
{
    public class AppointmentController : Controller
    {
        readonly IAppointmentService _appointmentService;


        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
           
            return View(await _appointmentService.GetAllAppointmentsAsync());
        }
        [HttpPost]
        public async Task<IEnumerable<Appointment>> GetAllAppointments(int userId)
        {
            return View(await _appointmentService.GetAllAppointmentsAsync(userId));

        }




        public async Task<IActionResult> GetAppointment(int id)
        {
            return View(await _appointmentService.GetAppointmentByIdAsync(id));
        }


        public async Task<IActionResult> AddAppointment()
        {

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

using Clinic_Appointment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorAsync(Doctor doctor);
        Task<int> DeleteDoctorAsync(int id);
        //Task<IActionResult> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentsByDoctorIdAsync(int id);
    }
}

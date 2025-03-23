using Clinic_Appointment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorAsync(Doctor doctor);
        Task<int> DeleteDoctorAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentsByDoctorIdAsync(int id);
    }
}

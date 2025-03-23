using Clinic_Appointment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Repository
{
    public interface IAppointmentRepository
    {
        //Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string userId);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task<int> UpdateAppointmentStatusAsync(int id, string status);
        Task<int> DeleteAppointmentAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    }
}

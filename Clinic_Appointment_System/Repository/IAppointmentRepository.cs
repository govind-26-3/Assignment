using Clinic_Appointment_System.Models;

namespace Clinic_Appointment_System.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentStatusAsync(int id, string status);
        Task DeleteAppointmentAsync(int id);
    }
}

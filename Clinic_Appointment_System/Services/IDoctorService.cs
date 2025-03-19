using Clinic_Appointment_System.Models;

namespace Clinic_Appointment_System.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorAsync(int id);
        Task<int> DeleteDoctorAsync(int id);
    }
}

using Clinic_Appointment_System.Models;

namespace Clinic_Appointment_System.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorAsync(Doctor doctor);
        Task<int> DeleteDoctorAsync(int id);
    }
}

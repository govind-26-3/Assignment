using Clinic_Appointment_System.Exceptions;
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Repository;

namespace Clinic_Appointment_System.Services
{
    public class DoctorService : IDoctorService
    {
        readonly IDoctorRepository _docRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _docRepository = doctorRepository;
        }
        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            return  await _docRepository.AddDoctorAsync(doctor);
        }

        public async Task<int> DeleteDoctorAsync(int id)
        {
            return await _docRepository.DeleteDoctorAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _docRepository.GetAllDoctorsAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _docRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
                throw new DoctorNotFoundException($"Doctor with Id:{id} not found");
            return doctor;
        }

        public async Task<int> UpdateDoctorAsync(int id)
        {
            return await _docRepository.UpdateDoctorAsync(id);
        }
    }
}

using Clinic_Appointment_System.Context;
using Clinic_Appointment_System.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Clinic_Appointment_System.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }

        public Task AddDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDoctorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.Include(b => b.Appointments).ToListAsync();
        }

        public Task<Doctor> GetDoctorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}

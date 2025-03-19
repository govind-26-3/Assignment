using Clinic_Appointment_System.Context;
using Clinic_Appointment_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;


namespace Clinic_Appointment_System.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteDoctorAsync(int id)
        {
            var doctor = await GetDoctorByIdAsync(id);

            _context.Doctors.Remove(doctor);
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.Include(b => b.Appointments).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.Include(d => d.Appointments).FirstOrDefaultAsync(b => b.Id == id); ;
        }

        public async Task<int> UpdateDoctorAsync(int id)
        {
            var doctor =await GetDoctorByIdAsync(id);
            if (doctor!=null)
            {
                doctor.Specialty = 
            }
        }
    }
}

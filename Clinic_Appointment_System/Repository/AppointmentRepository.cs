using Clinic_Appointment_System.Constants;
using Clinic_Appointment_System.Context;
using Clinic_Appointment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointment_System.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
         readonly ClinicContext _context;

        public AppointmentRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == userId)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAppointmentStatusAsync(int id, string status)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            if (Enum.TryParse(status, true, out Status parStatus))
            {
                
                appointment.Status = parStatus;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
               return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            //return await _context.Appointments.ToListAsync();
            return await _context.Appointments.Include(d=>d.Doctor).Include(p=>p.Patient).ToListAsync();
        }
    }
}

using Clinic_Appointment_System.Exceptions;
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointment_System.Services
{
    public class AppointmentService : IAppointmentService
    {
        IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public Task AddAppointmentAsync(Appointment appointment)
        {
            return _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            return await _appointmentRepository.DeleteAppointmentAsync(id);
        }

        public Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId)
        {
            return _appointmentRepository.GetAllAppointmentsAsync(userId);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            var appointment = _appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException($"Appointment not exist with id:{id}");
            }
            return appointment;
        }

        public Task<int> UpdateAppointmentStatusAsync(int id, string status)
        {
            return _appointmentRepository.UpdateAppointmentStatusAsync(id, status);
        }
    }
}

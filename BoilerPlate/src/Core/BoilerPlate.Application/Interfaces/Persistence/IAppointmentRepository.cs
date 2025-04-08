using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Domain.Entities;

namespace BoilerPlate.Application.Interfaces.Persistence
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllDoctorsAsync();
        Task<int> AddDoctorAsync(Appointment appointment);
        Task<int> UpdateDoctorAsync(Appointment appointment);
        Task<int> DeleteDoctorAsync(int id);
    }
}

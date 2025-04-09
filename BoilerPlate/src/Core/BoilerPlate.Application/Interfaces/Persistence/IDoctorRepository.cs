using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Domain.Entities;

namespace BoilerPlate.Application.Interfaces.Persistence
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorsByIdAsync(int id);
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorAsync(int id ,Doctor doctor);
        Task<int> DeleteDoctorAsync(int id);
    }
}

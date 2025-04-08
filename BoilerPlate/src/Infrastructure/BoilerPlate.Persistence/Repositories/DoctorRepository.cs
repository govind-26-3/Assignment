using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Application.Interfaces.Persistence;
using BoilerPlate.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BoilerPlate.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        readonly ApplicationDbContext _applicationDbContext;

        public DoctorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            await _applicationDbContext.Doctors.AddAsync(doctor);
            return await _applicationDbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteDoctorAsync(int id)
        {
            var existingDoctor = await _applicationDbContext.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);
            _applicationDbContext.Doctors.Remove(existingDoctor);

            return await _applicationDbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _applicationDbContext.Doctors.ToListAsync();
        }

        public Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}

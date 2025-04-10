using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Application.Exceptions;
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
            //var existingDoctor = await _applicationDbContext.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);
            var existingDoctor = await GetDoctorsByIdAsync(id);
            if (existingDoctor == null)
            {

                throw new NotFoundException($"Doctor not with id:{id} found");

            }
            _applicationDbContext.Doctors.Remove(existingDoctor);

            return await _applicationDbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _applicationDbContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorsByIdAsync(int id)
        {
           var doctor =await _applicationDbContext.Doctors.FindAsync(id);
            if (doctor == null) {

                throw new NotFoundException($"Doctor not with id:{id} found");

            }
            return doctor;
        }

        public async Task<int> UpdateDoctorAsync(int id, Doctor doctor)
        {

            var updatedDoctor = await GetDoctorsByIdAsync(id);

            updatedDoctor.Name = doctor.Name;   
            updatedDoctor.Speciality = doctor.Speciality;

            return await _applicationDbContext.SaveChangesAsync();

        }
    }
}

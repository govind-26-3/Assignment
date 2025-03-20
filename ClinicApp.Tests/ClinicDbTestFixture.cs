using Clinic_Appointment_System.Context;
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Tests
{
    public class ClinicDbTestFixture

    {

        internal ClinicContext _clinicContext;

        public IDoctorRepository DoctorRepository { get; set; }

        public ClinicDbTestFixture()
        {

            var clinicDbContextoptions = new DbContextOptionsBuilder<ClinicContext>().UseInMemoryDatabase("ClinicLocalDb").Options;
            var _clinicContext = new ClinicContext(clinicDbContextoptions);
            _clinicContext.Add(new Doctor { DoctorId = 5, Name = "Vanishree", Speciality = "BDS" });
            _clinicContext.SaveChanges();
            DoctorRepository = new DoctorRepository(_clinicContext);
        }
    }
}

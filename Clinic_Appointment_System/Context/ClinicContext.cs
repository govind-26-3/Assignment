using Clinic_Appointment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointment_System.Context
{
    public class ClinicContext : DbContext
    {
        public ClinicContext( DbContextOptions<ClinicContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


    }
}

using Clinic_Appointment_System.Configurations;
using Clinic_Appointment_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointment_System.Context
{
    public class ClinicContext : IdentityDbContext<User>
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new RoleSeedConfiguration());
            //builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.Entity<Appointment>()
               .HasOne(a => a.Patient)
               .WithMany()
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


    }
}

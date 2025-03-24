using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic_Appointment_System.Configurations
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    //a76f06ef-4878-49cb-o7e2-6489cb3454ba
                    Id = "a76f06ef-4878-49cb-o7e2-6489cb3454ba",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole
                 {
                     Id = "a76f06ef-4878-49cb-b8e2-6489cb3454ba",
                     Name = "Patient",
                     NormalizedName = "PATIENT"
                 },
                 new IdentityRole
                 {
                     Id = "a76f06ef-4878-49cb-c9e2-6489cb3454ba",
                     Name = "Doctor",
                     NormalizedName = "DOCTOR"
                 }
                );
        }
    }
}

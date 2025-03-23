using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic_Appointment_System.Configurations
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    
                    UserId = "3d31173d-9396-46aa-999a-49a59c46d3ad",
                    RoleId = "a76f06ef-4878-49cb-o7e2-6489cb3454ba",

                });
        }
    }
}

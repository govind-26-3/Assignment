using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {             
                           //41776008 - 6086 - 1fbf - b923 - 2879a6680b9a
                   RoleId = "41776008 - 6086 - 1ebe - b923 - 2879a6680b9a",
                   UserId = "41776062 - 6087 - 1fbf - b923 - 2879a6680b9a"

               },
            new IdentityUserRole<string>
            {
                RoleId = "41886008 - 6086 - 1dbd - b923 - 2879a6680b9a",
                UserId = "41776062 - 6088 - 1fcf - b923 - 2879a6680b9a"

            }
               );
        }
    }
}

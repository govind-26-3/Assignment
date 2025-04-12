using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoilerPlate.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<String>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {

                   RoleId = "41886008 - 6086 - 1cbc - b923 - 2879a6680b9a",
                   UserId = "41776062 - 6087 - 1ebe - b923 - 2879a6680b9a"

               },
            new IdentityUserRole<string>
            {
                RoleId = "41886008 - 6086 - 1dbd - b923 - 2879a6680b9a",
                UserId = "41776062 - 6087 - 1rbr - b923 - 2879a6680b9a"

            }
               );
        }
    }
}

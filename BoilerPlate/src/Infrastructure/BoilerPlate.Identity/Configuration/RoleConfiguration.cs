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
    public  class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "41886008 - 6086 - 1dbd - b923 - 2879a6680b9a",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "41886008 - 6086 - 1cbc - b923 - 2879a6680b9a",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
                );
        }

        
    }
}

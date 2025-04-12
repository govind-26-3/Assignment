using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoilerPlate.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "41776062 - 6087 - 1ebe - b923 - 2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail="ADMIN@gmail.com",
                    FirstName = "admin",
                    LastName = "system",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL@COM",
                    PasswordHash=hasher.HashPassword(null,"Admin@123")
                },
                new ApplicationUser
                {
                    Id = "41776062 - 6087 - 1rbr - b923 - 2879a6680b9a",
                    Email = "raghu@gmail.com",
                    NormalizedEmail = "RAGHU@GMAIL.com",
                    FirstName = "Raghu",
                    LastName = "ram",
                    UserName = "raghu@gmail.com",
                    NormalizedUserName = "RAGHU@GMAIL@COM",
                    PasswordHash = hasher.HashPassword(null, "Raghu@123")
                });


        }
    }
}

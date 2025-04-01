
using ECommerceApplication.Identity.Model;
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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "41776062 - 6087 - 1fbf - b923 - 2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Admin",
                    LastName = "system",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")

                },
                 new ApplicationUser
                 {
                     Id = "41776062 - 6088 - 1fcf - b923 - 2879a6680b9a",
                     Email = "Raghu@gmail.com",
                     NormalizedEmail = "RAGHU@GMAIL.COM",
                     FirstName = "raghu",
                     LastName = "ram",
                     UserName = "Raghu@gmail.com",
                     NormalizedUserName = "RAGHU@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Raghu@123")
                 }


                );
        }
    }
}

using ECommerceApplication.Identity.Configuration;
using ECommerceApplication.Identity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerceApplication.Identity.Context
{
    public class ECommerceAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceAppIdentityDbContext(DbContextOptions<ECommerceAppIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}

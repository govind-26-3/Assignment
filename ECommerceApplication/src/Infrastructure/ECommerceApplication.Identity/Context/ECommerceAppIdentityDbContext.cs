﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Identity.Context
{
    public class ECommerceAppIdentityDbContext : IdentityDbContext
    {
        public ECommerceAppIdentityDbContext(DbContextOptions<ECommerceAppIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}

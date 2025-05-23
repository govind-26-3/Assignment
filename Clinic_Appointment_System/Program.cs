using Clinic_Appointment_System.Context;
using Clinic_Appointment_System.Models;
using Clinic_Appointment_System.Repository;
using Clinic_Appointment_System.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;





namespace Clinic_Appointment_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string conn = builder.Configuration.GetConnectionString("LocalConnectionString");
            builder.Services.AddDbContext<ClinicContext>(opt => opt.UseSqlServer(conn));

            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();

            builder.Services.AddIdentity<User, IdentityRole>()
                            .AddEntityFrameworkStores<ClinicContext>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //builder.Services.AddDbContext<>
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using NMC.Core.Services;
using NMC.Infrastructure.Services;
using SBMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMC.Infrastructure
{
    public static class InfrastructureServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ITypesRepository, TypesRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IAdmissionRepository, AdmissionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISBMenu, NMC.Infrastructure.MenuComponent.SBMenu>();
        }
    }
}

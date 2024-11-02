using HRManagement.BL.MappingProfile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using HRManagement.BL.Managers.Employee;

namespace HRManagement.BL
{
    public static class ServicesExtension
    {
        public static void AddBLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(EmployeeMappings));

            services.AddScoped<IEmployeeManager, EmployeeManager>();

        }
    } 

}

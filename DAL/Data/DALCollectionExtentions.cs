using DAL.Services;
using DAL.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApplication.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public static class DALCollectionExtentions
    {
        public static IServiceCollection AddDataLibraryCollection(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQueueDalService, QueueDalService>();

            return services;
        }
    }
}


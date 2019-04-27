using BAL.Services;
using BAL.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Data
{
    public static class BALCollectionExtentions
    {
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection services)
        {
            services.AddScoped<IQueueBalService, QueueBalService>();

            return services;
        }
    }
}

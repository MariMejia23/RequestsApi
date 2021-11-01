using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestsApi.Interfaces;
using RequestsApi.Repository;
using RequestsApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Installers
{
    public static class ServicesInstaller
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        { 
            #region UnitOfWork
            services.AddTransient<UnitOfWork>();
            #endregion

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IStatusService, StatusService>();

            return services;
        }

    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RequestsApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Installers
{
    public static class DatabasesInstaller
    {
        private static IConfiguration Configuration { get; set; }

        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration config)
        {
            Configuration = config;
            services.AddRequestsDbContext();
            return services;

        }

        private static IServiceCollection AddRequestsDbContext(this IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("RequestsDB");
            services.AddDbContext<RequestsDbContext>(opts => { opts.UseSqlServer(connString); });
            return services;
        }
    }
}

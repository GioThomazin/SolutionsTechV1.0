using Microsoft.Extensions.DependencyInjection;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Business.Services;
using SolutionsTech.Data.Repository;

namespace SolutionsTech.CrossCutting.Extensions
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Repo

            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<IRepositoryBase<Scheduling>, RepositoryBase<Scheduling>>();

            //Service

            services.AddScoped<ISchedulingService, SchedulingService>();
        }
    }
}

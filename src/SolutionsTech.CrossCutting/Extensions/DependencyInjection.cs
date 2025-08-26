using Microsoft.Extensions.DependencyInjection;
using SolutionsTech.Business.Entities;
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

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IRepositoryBase<Brand>, RepositoryBase<Brand>>();
			
			services.AddScoped<IFormPaymentRepository, FormPaymentRepository>();
			services.AddScoped<IRepositoryBase<FormPayment>, RepositoryBase<FormPayment>>();

            services.AddScoped<IInvoicingRepository, InvoicingRepository>();
            services.AddScoped<IRepositoryBase<Invoicing>, RepositoryBase<Invoicing>>();

            services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IRepositoryBase<Product>, RepositoryBase<Product>>();

			//Service

			services.AddScoped<ISchedulingService, SchedulingService>();
            services.AddScoped<IBrandService, BrandService>();
			services.AddScoped<IFormPaymentService, FormPaymentService>();
		    services.AddScoped<IInvoicingService, InvoicingService>();
			services.AddScoped<IProductService, ProductService>();
		}
    }
}

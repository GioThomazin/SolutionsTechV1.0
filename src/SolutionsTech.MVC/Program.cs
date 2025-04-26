using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Services;
using SolutionsTech.Data.Context;
using SolutionsTech.Data.Repository;
using SolutionsTech.MVC.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ModelMapper));
builder.Services.AddMvc();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

//Repo

builder.Services.AddScoped<IRepositoryBase<Scheduling>, RepositoryBase<Scheduling>>();
builder.Services.AddScoped<ISchedulingRepository, SchedulingRepository>();

//Service

builder.Services.AddScoped<ISchedulingService, SchedulingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
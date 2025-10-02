using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.CrossCutting.Extensions;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.AutoMapper;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ModelMapper));
builder.Services.AddMvc();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews(options =>
{
	options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.RegisterServices();

var app = builder.Build();

var cultureInfo = new CultureInfo("pt-BR");
app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture(cultureInfo),
	SupportedCultures = new List<CultureInfo> { cultureInfo },
	SupportedUICultures = new List<CultureInfo> { cultureInfo }
});

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Adicionando o middleware de autenticação
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapRazorPages();

// Em Program.cs (ASP.NET Core 6+)
app.MapControllerRoute(
	name: "login",
	pattern: "Login",
	defaults: new { controller = "Auth", action = "Index" });

app.Run();

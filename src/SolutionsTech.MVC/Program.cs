using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.CrossCutting;
using SolutionsTech.CrossCutting.Extensions;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ModelMapper));
builder.Services.AddMvc();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

//pegar o token e gerar a chave encodada
var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(JwtSettingsSection); //configurando, populando minha classe com os dados do appsettings.json

var jwtSettings = JwtSettingsSection.Get<JwtSettings>(); // buscando para criar a variavel com os dados da minha classe com os dados populados no appsettings.json
var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Segredo); // convertendo a chave em bytes

//voce api abaixo, tem um padrao de autenticação, que é para usar o json web token.
//o challenge e para validar se o token é valido, e o authenticate é para autenticar o token
builder.Services.AddAuthentication(options =>
{
	// Configurar o esquema padrão para Cookies
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
// Configurar autenticação por Cookies
.AddCookie(options =>
{
	options.LoginPath = "/Auth/Login"; // ajuste para a rota correta do seu login
	options.LogoutPath = "/Auth/Logout"; // ajuste para a rota correta do seu logout
})
// Configurar autenticação JWT
.AddJwtBearer("Bearer", options =>
{
	options.RequireHttpsMetadata = true; //requer autenticação
	options.SaveToken = true; //salva o token
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		//IssuerSigningKey = new SymmetricSecurityKey, //valida a chave de assinatura do emissor
		IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), //chave de assinatura simétrica
		ValidateIssuer = false, //não valida o emissor
		ValidateAudience = false, //não valida o público
		ClockSkew = TimeSpan.Zero //não permite atraso no relógio
	};
});

builder.Services.AddControllersWithViews(options =>
{
	options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.RegisterServices();

var app = builder.Build();

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

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

//voce api abaixo, tem um padrao de autentica��o, que � para usar o json web token.
//o challenge e para validar se o token � valido, e o authenticate � para autenticar o token
builder.Services.AddAuthentication(options =>
{
	// Configurar o esquema padr�o para Cookies
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
// Configurar autentica��o por Cookies
.AddCookie(options =>
{
	options.LoginPath = "/Auth/Login"; // ajuste para a rota correta do seu login
	options.LogoutPath = "/Auth/Logout"; // ajuste para a rota correta do seu logout
})
// Configurar autentica��o JWT
.AddJwtBearer("Bearer", options =>
{
	options.RequireHttpsMetadata = true; //requer autentica��o
	options.SaveToken = true; //salva o token
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		//IssuerSigningKey = new SymmetricSecurityKey, //valida a chave de assinatura do emissor
		IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), //chave de assinatura sim�trica
		ValidateIssuer = false, //n�o valida o emissor
		ValidateAudience = false, //n�o valida o p�blico
		ClockSkew = TimeSpan.Zero //n�o permite atraso no rel�gio
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

app.UseAuthentication(); // Adicionando o middleware de autentica��o
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

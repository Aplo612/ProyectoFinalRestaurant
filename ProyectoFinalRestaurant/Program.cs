using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Controllers;
using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Servicios.Contrato;
using ProyectoFinalRestaurant.Servicios.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.Add(new ServiceDescriptor(typeof(IPlatos), new PlatosService()));
builder.Services
    .Add(new ServiceDescriptor(typeof(IBoletas), new BoletasRepository()));
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RestaurantC>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped<IPedidos, PedidosService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Inicio/IniciarSesion";
		options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
	});

builder.Services.AddControllersWithViews(options => {
	options.Filters.Add(
			new ResponseCacheAttribute
			{
				NoStore = true,
				Location = ResponseCacheLocation.None,
			}
		);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.Run();

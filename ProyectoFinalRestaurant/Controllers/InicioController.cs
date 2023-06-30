using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Recursos;
using ProyectoFinalRestaurant.Servicios.Implementacion;
using System.Security.Claims;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Controllers
{
	public class InicioController : Controller
	{
		private readonly IUsuario _usuarioServicio;
		public InicioController(IUsuario usuarioServicio)
		{
			_usuarioServicio = usuarioServicio;
		}

		public IActionResult Registrarse()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registrarse(Usuario modelo)
		{
			modelo.Contraseña = Utilidades.EncriptarClave(modelo.Contraseña);

			Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

			if (usuario_creado.IdUsuario > 0)
				return RedirectToAction("IniciarSesion", "Inicio");

			ViewData["Mensaje"] = "No se pudo crear el usuario";
			return View();
		}

		public IActionResult IniciarSesion()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IniciarSesion(string correo, string clave)
		{

			Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(correo, Utilidades.EncriptarClave(clave));

			if (usuario_encontrado == null)
			{
				ViewData["Mensaje"] = "No se encontraron coincidencias";
				return View();
			}

			List<Claim> claims = new List<Claim>() {
				new Claim(ClaimTypes.Name, usuario_encontrado.NombreCompleto)
			};

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			AuthenticationProperties properties = new AuthenticationProperties()
			{
				AllowRefresh = true
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				properties
				);

            if (usuario_encontrado.Esadmin == true)
            {
                return RedirectToAction("Admin", "Home");
            }

            return RedirectToAction("VistaInicial", "Home");
		}
	}
}

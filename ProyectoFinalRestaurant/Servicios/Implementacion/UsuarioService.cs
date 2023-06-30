using ProyectoFinalRestaurant.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Models;

namespace ProyectoFinalRestaurant.Servicios.Implementacion
{
	public class UsuarioService: IUsuario
	{
		private readonly RestaurantC _restaurant;
		public UsuarioService(RestaurantC restaurant) 
		{
			_restaurant=restaurant;
		}

		public async Task<Usuario> GetUsuario(string email, string contraseña)
		{
			Usuario usuario_encontrado = await _restaurant.Usuarios.Where(u => u.Email == email && u.Contraseña == contraseña)
				 .FirstOrDefaultAsync();

			return usuario_encontrado;
		}

		public async Task<Usuario> SaveUsuario(Usuario modelo)
		{
			_restaurant.Usuarios.Add(modelo);
			await _restaurant.SaveChangesAsync();
			return modelo;
		}
	}
}

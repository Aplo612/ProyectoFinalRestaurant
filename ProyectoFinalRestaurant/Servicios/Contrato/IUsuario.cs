using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Models;

namespace ProyectoFinalRestaurant.Servicios.Contrato
{
	public interface IUsuario
	{
		Task<Usuario> GetUsuario(string email, string contraseña);

		Task<Usuario> SaveUsuario(Usuario modelo);
	}
}

using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Servicios.Implementacion
{
    public class PlatosService: IPlatos
    {
        private RestaurantC conexion = new RestaurantC();
        public Plato edite(int id)
        {
            Plato objEncontrado = conexion.Platos.Where(idP => idP.IdPlato == id).Single();
            return objEncontrado;
        }
        public void remove(int id)
        {
            Plato objEncontrado = conexion.Platos.Where(idP => idP.IdPlato == id).Single();
            conexion.Platos.Remove(objEncontrado);
            conexion.SaveChanges();
        }

        public void editeDetails(Plato obj)
        {
            Plato objAModificar = conexion.Platos.Where(idP => idP.IdPlato == obj.IdPlato).FirstOrDefault();
            if (objAModificar != null)
            {
                objAModificar.Nombre = obj.Nombre;
                objAModificar.Descripcion = obj.Descripcion;
                objAModificar.Precio = obj.Precio;
                objAModificar.MenuDelDia = obj.MenuDelDia;
            }
            conexion.SaveChanges();
        }
        public IEnumerable<Plato> GetAllPlatos()
        {
            return conexion.Platos;
        }
        public void add(Plato obj)
        {
            conexion.Platos.Add(obj);
            conexion.SaveChanges();
        }
    }
}

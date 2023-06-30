using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Servicios.Implementacion
{
    public class BoletasRepository: IBoletas
    {
        private RestaurantC conexion = new RestaurantC();
        
        public IEnumerable<Boletum> GetAllBoletas()
        {
            return conexion.Boleta;
        }
    }
}

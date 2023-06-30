using ProyectoFinalRestaurant.Models;

namespace ProyectoFinalRestaurant.Servicios.Contrato
{
    public interface IBoletas
    {
        IEnumerable<Boletum> GetAllBoletas();
    }
}

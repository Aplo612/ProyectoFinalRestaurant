using ProyectoFinalRestaurant.Models;

namespace ProyectoFinalRestaurant.Servicios.Contrato
{
    public interface IPlatos
    {
        IEnumerable<Plato> GetAllPlatos();
        void add(Plato obj);
        void remove(int id);
        Plato edite(int id);
        void editeDetails(Plato obj);
    }
}

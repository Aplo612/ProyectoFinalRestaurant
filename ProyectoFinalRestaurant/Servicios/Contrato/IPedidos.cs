using ProyectoFinalRestaurant.Models;

namespace ProyectoFinalRestaurant.Servicios.Contrato
{
    public interface IPedidos
    {
        Task<bool> RealizarPedido(string listOfPlates, int mesa);
        public void EditarEstadoPedido(string id, string nuevoEstado);
        public void CrearBoleta(string id);
    }
}

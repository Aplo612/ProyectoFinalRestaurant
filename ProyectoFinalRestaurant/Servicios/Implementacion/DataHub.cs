using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ProyectoFinalRestaurant.Servicios.Implementacion
{
    public class DataHub: Hub
    {
        public async Task SendData(string data)
        {
            await Clients.All.SendAsync("ReceiveData", data);
        }
    }
}

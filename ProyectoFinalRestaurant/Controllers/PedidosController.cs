using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IPedidos _pedidosService;

        public PedidosController(IPedidos pedidosService)
        {
            _pedidosService = pedidosService;
        }
        [HttpPost]
        public async Task<IActionResult> RealizarPedido(string listOfPlates, int mesa)
        {
            var result = await _pedidosService.RealizarPedido(listOfPlates, mesa);
            if (result)
            {
                return RedirectToAction("Mesas", "Home");
            }
            else
            {
                return BadRequest("No se pudo realizar el pedido.");
            }
        }
        public IActionResult EnEspera(string id)
        {
            _pedidosService.EditarEstadoPedido(id, "EnEspera");
            return RedirectToAction("VerPedidos","Ver");
        }
        public IActionResult EnPreparacion(string id)
        {
            _pedidosService.EditarEstadoPedido(id, "EnPreparacion");
            return RedirectToAction("VerPedidos", "Ver");
        }
        public IActionResult Entregado(string id)
        {
            _pedidosService.EditarEstadoPedido(id, "Entregado");
            return RedirectToAction("VerPedidos", "Ver");
        }
        public IActionResult Pagado(string id)
        {
            _pedidosService.EditarEstadoPedido(id, "Pagado");
            return RedirectToAction("VistaInicial", "Home");
        }

    }
}

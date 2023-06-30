using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Controllers
{
    [Authorize]
    public class VerController : Controller
    {

        private readonly RestaurantC _context;
        private readonly IPedidos _pedidosService;

        public VerController(RestaurantC context, IPedidos pedidosService)
        {
            _context = context;
            _pedidosService = pedidosService;
        }
        public IActionResult VerPedidos()
        {
            var model = _context.DetallePedidos
                .Include(dp => dp.IdPlatoNavigation)
                .Include(dp => dp.IdPedidoNavigation)
                .ThenInclude(p => p.Boleta)
                .ToList();
            return View(model);
        }
        public IActionResult GenerarBoletas()
        {
            var model = _context.DetallePedidos
                .Include(dp => dp.IdPlatoNavigation)
                .Include(dp => dp.IdPedidoNavigation)
                .ThenInclude(p => p.Boleta)
                .ToList();
            return View(model);
        }
        public IActionResult Boleta(string id) 
        {
            _pedidosService.CrearBoleta(id);
            int idInt = int.Parse(id);

            var boleta = _context.Boleta
                .Include(b => b.IdPedidoNavigation)  // Incluir el Pedido
                .ThenInclude(p => p.DetallePedidos) // Incluir DetallePedidos dentro de Pedido
                .ThenInclude(dp => dp.IdPlatoNavigation) // Incluir Plato dentro de DetallePedidos
                .FirstOrDefault(b => b.IdPedido == idInt); // Filtrar por IdPedido

            return View(boleta);
        }
    }
}

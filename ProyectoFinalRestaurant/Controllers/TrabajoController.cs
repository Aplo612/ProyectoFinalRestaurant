using Microsoft.AspNetCore.Mvc;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Controllers
{
    public class TrabajoController : Controller
    {
        private readonly IBoletas _boletas;

        public TrabajoController(IBoletas boletas)
        {
            _boletas = boletas;
        }

        public IActionResult Index()
        {
            return View(_boletas.GetAllBoletas());
        }

        public IActionResult BoletasIntervalo(int menor, int mayor)
        {
            var boletas = _boletas.GetAllBoletas();

            var boletasFiltradas = boletas.Where(b => b.Total >= menor && b.Total <= mayor).ToList();

            ViewBag.BoletasFiltradas = boletasFiltradas;

            return View("Index", boletas);
        }
    }
}

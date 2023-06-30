using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Servicios.Contrato;

namespace ProyectoFinalRestaurant.Controllers
{
    [Authorize]
    public class PlatoController : Controller
    {
        private readonly IPlatos _platos;
        public PlatoController(IPlatos platos)
        {
            _platos = platos;
        }
        [Route("/plato/mesa")]
        public IActionResult Mesa()
        {
            return View(_platos.GetAllPlatos());
        }
        [Route("/plato/editarPlatos")]
        public IActionResult EditarPlatos()
        {
            return View(_platos.GetAllPlatos());
        }
        public IActionResult Grabar(Plato obj)
        {
            _platos.add(obj);
            return RedirectToAction("EditarPlatos");
        }
        [Route("plato/Modificar/{id}")]
        public IActionResult Modificar(int id)
        {
            return View(_platos.edite(id));
        }
        public IActionResult ModificarPlato(Plato obj)
        {
            _platos.editeDetails(obj);
            return RedirectToAction("EditarPlatos");
        }
        public IActionResult nuevo()
        {
            return View();
        }
        public IActionResult Eliminar(int id)
        {
            _platos.remove(id);
            return RedirectToAction("EditarPlatos");
        }
    }
}

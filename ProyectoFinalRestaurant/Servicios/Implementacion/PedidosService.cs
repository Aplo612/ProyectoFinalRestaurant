using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalRestaurant.Models;
using ProyectoFinalRestaurant.Servicios.Contrato;


namespace ProyectoFinalRestaurant.Servicios.Implementacion
{
    public class PedidosService:IPedidos
    {
        private readonly RestaurantC _context;

        public PedidosService(RestaurantC context)
        {
            _context = context;
        }

        public async Task<bool> RealizarPedido(string listOfPlates, int mesa)
        {
            try
            {
                var pedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    Estado = "En espera",
                    Mesa = mesa,
                };

                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();

                string[] detalles = listOfPlates.Split(';');
                foreach (string detalle in detalles)
                {
                    string[] campos = detalle.Split(',');
                    int idPlato = int.Parse(campos[0]);
                    int cantidad = int.Parse(campos[1]);
                    decimal subtotal = decimal.Parse(campos[2]);

                    var plato = await _context.Platos.FindAsync(idPlato);
                    if (plato == null)
                    {
                        return false;
                    }

                    var detallePedido = new DetallePedido
                    {
                        IdPedido = pedido.IdPedido,
                        IdPlato = idPlato,
                        Cantidad = cantidad,
                        Precio = subtotal,
                    };
                    _context.DetallePedidos.Add(detallePedido);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void EditarEstadoPedido(string id,string nuevoEstado) 
        {
            int idInt;
            if (!int.TryParse(id, out idInt))
            {
                throw new ArgumentException("id debe ser un número válido.");
            }

            var objsEncontrado = (from tpedi in _context.Pedidos
                                 where tpedi.IdPedido == idInt
                                 select tpedi).Single();

            if (objsEncontrado != null)
            {
                objsEncontrado.Estado = nuevoEstado;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró ningún pedido con id {idInt}");
            }
        }
        public void CrearBoleta(string id) 
        {
            int idInt = int.Parse(id);
            var objsEncontrado = _context.Pedidos
                        .Include(p => p.DetallePedidos)  // Incluir los DetallePedidos
                        .Single(p => p.IdPedido == idInt);

            decimal total = objsEncontrado.DetallePedidos.Sum(dp => dp.Precio);

            var boleta = new Boletum()
            {
                IdPedido = idInt,
                Total = total,
                Fecha = objsEncontrado.Fecha
            };
            _context.Boleta.Add(boleta);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProyectoFinalRestaurant.Models;

public partial class DetallePedido
{
    public int IdDetallePedido { get; set; }

    public int IdPedido { get; set; }

    public int IdPlato { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Plato IdPlatoNavigation { get; set; } = null!;
}

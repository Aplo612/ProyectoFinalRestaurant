using System;
using System.Collections.Generic;

namespace ProyectoFinalRestaurant.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public int Mesa { get; set; }

    public virtual ICollection<Boletum> Boleta { get; set; } = new List<Boletum>();

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}

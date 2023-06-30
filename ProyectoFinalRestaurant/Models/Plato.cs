using System;
using System.Collections.Generic;

namespace ProyectoFinalRestaurant.Models;

public partial class Plato
{
    public int IdPlato { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool MenuDelDia { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}

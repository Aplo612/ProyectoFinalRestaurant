using System;
using System.Collections.Generic;

namespace ProyectoFinalRestaurant.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public bool Esadmin { get; set; }
}

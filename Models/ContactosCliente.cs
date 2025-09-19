using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class ContactosCliente
{
    public int IdContacto { get; set; }

    public int IdCliente { get; set; }

    public string NombreContacto { get; set; } = null!;

    public string? Cargo { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool? EsPrincipal { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<ComunicacionesCliente> ComunicacionesClientes { get; set; } = new List<ComunicacionesCliente>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class TiposComunicacion
{
    public int IdTipoComunicacion { get; set; }

    public string NombreTipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Icono { get; set; }

    public virtual ICollection<ComunicacionesCliente> ComunicacionesClientes { get; set; } = new List<ComunicacionesCliente>();
}

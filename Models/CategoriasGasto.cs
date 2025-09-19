using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class CategoriasGasto
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<GastosProyecto> GastosProyectos { get; set; } = new List<GastosProyecto>();
}

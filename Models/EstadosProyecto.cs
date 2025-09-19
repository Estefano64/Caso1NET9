using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class EstadosProyecto
{
    public int IdEstado { get; set; }

    public string NombreEstado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? OrdenVisualizacion { get; set; }

    public string? ColorHex { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

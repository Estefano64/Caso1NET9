using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class EstadosTarea
{
    public int IdEstadoTarea { get; set; }

    public string NombreEstado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? EsEstadoFinal { get; set; }

    public string? ColorHex { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

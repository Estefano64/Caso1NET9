using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class TiposProyecto
{
    public int IdTipo { get; set; }

    public string NombreTipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

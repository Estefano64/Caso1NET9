using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class HitosProyecto
{
    public int IdHito { get; set; }

    public int IdProyecto { get; set; }

    public string NombreHito { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly FechaPlanificada { get; set; }

    public DateOnly? FechaReal { get; set; }

    public bool? EsCompletado { get; set; }

    public decimal? PorcentajePeso { get; set; }

    public int? IdResponsable { get; set; }

    public string? Notas { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;

    public virtual Empleado? IdResponsableNavigation { get; set; }
}

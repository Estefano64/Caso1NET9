using System;
using System.Collections.Generic;

namespace caso2net.Models;

/// <summary>
/// Control de gastos y presupuesto por proyecto
/// </summary>
public partial class GastosProyecto
{
    public int IdGasto { get; set; }

    public int IdProyecto { get; set; }

    public int? IdCategoria { get; set; }

    public string Concepto { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateOnly FechaGasto { get; set; }

    public int IdRegistradoPor { get; set; }

    public string? Descripcion { get; set; }

    public string? NumeroFactura { get; set; }

    public string? Proveedor { get; set; }

    public bool? EsAprobado { get; set; }

    public DateOnly? FechaAprobacion { get; set; }

    public int? IdAprobadoPor { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Empleado? IdAprobadoPorNavigation { get; set; }

    public virtual CategoriasGasto? IdCategoriaNavigation { get; set; }

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;

    public virtual Empleado IdRegistradoPorNavigation { get; set; } = null!;
}

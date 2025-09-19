using System;
using System.Collections.Generic;

namespace caso2net.Models;

public partial class ProyectoEmpleado
{
    public int IdAsignacion { get; set; }

    public int IdProyecto { get; set; }

    public int IdEmpleado { get; set; }

    public string? RolEnProyecto { get; set; }

    public DateOnly FechaAsignacion { get; set; }

    public DateOnly? FechaDesasignacion { get; set; }

    public decimal? HorasAsignadasSemanales { get; set; }

    public decimal? TarifaPorHora { get; set; }

    public bool? Activo { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}

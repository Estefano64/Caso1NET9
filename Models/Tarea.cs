using System;
using System.Collections.Generic;

namespace caso2net.Models;

/// <summary>
/// Tareas específicas dentro de cada proyecto
/// </summary>
public partial class Tarea
{
    public int IdTarea { get; set; }

    public int IdProyecto { get; set; }

    public string NombreTarea { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdAsignado { get; set; }

    public int IdCreador { get; set; }

    public int IdEstadoTarea { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public DateOnly? FechaInicioEstimada { get; set; }

    public DateOnly? FechaFinEstimada { get; set; }

    public DateOnly? FechaInicioReal { get; set; }

    public DateOnly? FechaFinReal { get; set; }

    public decimal? HorasEstimadas { get; set; }

    public decimal? HorasTrabajadas { get; set; }

    public decimal? PorcentajeCompletado { get; set; }

    public string? Prioridad { get; set; }

    public string? Notas { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Empleado? IdAsignadoNavigation { get; set; }

    public virtual Empleado IdCreadorNavigation { get; set; } = null!;

    public virtual EstadosTarea IdEstadoTareaNavigation { get; set; } = null!;

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}

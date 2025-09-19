using System;
using System.Collections.Generic;

namespace caso2net.Models;

/// <summary>
/// Tabla principal de proyectos de consultoría
/// </summary>
public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string CodigoProyecto { get; set; } = null!;

    public string NombreProyecto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Objetivos { get; set; }

    public int IdCliente { get; set; }

    public int? IdTipoProyecto { get; set; }

    public int IdResponsable { get; set; }

    public int IdEstado { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFinEstimada { get; set; }

    public DateOnly? FechaFinReal { get; set; }

    public decimal PresupuestoEstimado { get; set; }

    public decimal? GastoReal { get; set; }

    public decimal? PorcentajeAvance { get; set; }

    public string? Prioridad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<ComunicacionesCliente> ComunicacionesClientes { get; set; } = new List<ComunicacionesCliente>();

    public virtual ICollection<GastosProyecto> GastosProyectos { get; set; } = new List<GastosProyecto>();

    public virtual ICollection<HitosProyecto> HitosProyectos { get; set; } = new List<HitosProyecto>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual EstadosProyecto IdEstadoNavigation { get; set; } = null!;

    public virtual Empleado IdResponsableNavigation { get; set; } = null!;

    public virtual TiposProyecto? IdTipoProyectoNavigation { get; set; }

    public virtual ICollection<ProyectoEmpleado> ProyectoEmpleados { get; set; } = new List<ProyectoEmpleado>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

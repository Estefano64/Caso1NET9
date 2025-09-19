using System;
using System.Collections.Generic;

namespace caso2net.Models;

/// <summary>
/// Información de empleados de la empresa
/// </summary>
public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NumeroEmpleado { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Puesto { get; set; }

    public int? IdDepartamento { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public decimal? SalarioBase { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<ComunicacionesCliente> ComunicacionesClientes { get; set; } = new List<ComunicacionesCliente>();

    public virtual ICollection<GastosProyecto> GastosProyectoIdAprobadoPorNavigations { get; set; } = new List<GastosProyecto>();

    public virtual ICollection<GastosProyecto> GastosProyectoIdRegistradoPorNavigations { get; set; } = new List<GastosProyecto>();

    public virtual ICollection<HitosProyecto> HitosProyectos { get; set; } = new List<HitosProyecto>();

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual ICollection<ProyectoEmpleado> ProyectoEmpleados { get; set; } = new List<ProyectoEmpleado>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Tarea> TareaIdAsignadoNavigations { get; set; } = new List<Tarea>();

    public virtual ICollection<Tarea> TareaIdCreadorNavigations { get; set; } = new List<Tarea>();
}

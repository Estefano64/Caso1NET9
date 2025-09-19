namespace caso2net.DTOs;

public class ProyectoDto
{
    public int IdProyecto { get; set; }
    public string CodigoProyecto { get; set; } = null!;
    public string NombreProyecto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? Objetivos { get; set; }
    public int IdCliente { get; set; }
    public string NombreCliente { get; set; } = null!;
    public int IdResponsable { get; set; }
    public string NombreResponsable { get; set; } = null!;
    public string EstadoProyecto { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public DateOnly? FechaFinReal { get; set; }
    public decimal PresupuestoEstimado { get; set; }
    public decimal? GastoReal { get; set; }
    public decimal? PorcentajeAvance { get; set; }
    public string? Prioridad { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }
}

public class CreateProyectoDto
{
    public string CodigoProyecto { get; set; } = null!;
    public string NombreProyecto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? Objetivos { get; set; }
    public int IdCliente { get; set; }
    public int? IdTipoProyecto { get; set; }
    public int IdResponsable { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public decimal PresupuestoEstimado { get; set; }
    public string? Prioridad { get; set; }
}

public class UpdateProyectoDto
{
    public string? NombreProyecto { get; set; }
    public string? Descripcion { get; set; }
    public string? Objetivos { get; set; }
    public int? IdResponsable { get; set; }
    public int? IdEstado { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public DateOnly? FechaFinReal { get; set; }
    public decimal? PresupuestoEstimado { get; set; }
    public decimal? PorcentajeAvance { get; set; }
    public string? Prioridad { get; set; }
}
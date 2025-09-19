namespace caso2net.DTOs;

public class TareaDto
{
    public int IdTarea { get; set; }
    public string NombreTarea { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int IdProyecto { get; set; }
    public string NombreProyecto { get; set; } = null!;
    public int? IdAsignado { get; set; }
    public string? NombreAsignado { get; set; }
    public int IdCreador { get; set; }
    public string NombreCreador { get; set; } = null!;
    public string EstadoTarea { get; set; } = null!;
    public DateOnly? FechaInicioEstimada { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public DateOnly? FechaInicioReal { get; set; }
    public DateOnly? FechaFinReal { get; set; }
    public decimal? HorasEstimadas { get; set; }
    public decimal? HorasTrabajadas { get; set; }
    public decimal? PorcentajeCompletado { get; set; }
    public string? Prioridad { get; set; }
    public string? Notas { get; set; }
    public DateOnly FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }
}

public class CreateTareaDto
{
    public string NombreTarea { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int IdProyecto { get; set; }
    public int? IdAsignado { get; set; }
    public int IdCreador { get; set; }
    public int IdEstadoTarea { get; set; }
    public DateOnly? FechaInicioEstimada { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public decimal? HorasEstimadas { get; set; }
    public string? Prioridad { get; set; }
    public string? Notas { get; set; }
}

public class UpdateTareaDto
{
    public string? NombreTarea { get; set; }
    public string? Descripcion { get; set; }
    public int? IdAsignado { get; set; }
    public int? IdEstadoTarea { get; set; }
    public DateOnly? FechaInicioEstimada { get; set; }
    public DateOnly? FechaFinEstimada { get; set; }
    public DateOnly? FechaInicioReal { get; set; }
    public DateOnly? FechaFinReal { get; set; }
    public decimal? HorasEstimadas { get; set; }
    public decimal? HorasTrabajadas { get; set; }
    public decimal? PorcentajeCompletado { get; set; }
    public string? Prioridad { get; set; }
    public string? Notas { get; set; }
}
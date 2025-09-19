namespace caso2net.DTOs;

public class ComunicacionDto
{
    public int IdComunicacion { get; set; }
    public int IdProyecto { get; set; }
    public string NombreProyecto { get; set; } = null!;
    public int? IdContactoCliente { get; set; }
    public string? NombreContacto { get; set; }
    public int IdEmpleado { get; set; }
    public string NombreEmpleado { get; set; } = null!;
    public string TipoComunicacion { get; set; } = null!;
    public string Asunto { get; set; } = null!;
    public string? Contenido { get; set; }
    public DateTime FechaComunicacion { get; set; }
    public int? DuracionMinutos { get; set; }
    public string? Ubicacion { get; set; }
    public bool? EsImportante { get; set; }
    public bool? RequiereSeguimiento { get; set; }
    public DateOnly? FechaSeguimiento { get; set; }
    public string? EstadoSeguimiento { get; set; }
    public string? ArchivoAdjunto { get; set; }
    public DateTime? FechaRegistro { get; set; }
}

public class CreateComunicacionDto
{
    public int IdProyecto { get; set; }
    public int? IdContactoCliente { get; set; }
    public int IdEmpleado { get; set; }
    public int IdTipoComunicacion { get; set; }
    public string Asunto { get; set; } = null!;
    public string? Contenido { get; set; }
    public DateTime FechaComunicacion { get; set; }
    public int? DuracionMinutos { get; set; }
    public string? Ubicacion { get; set; }
    public bool? EsImportante { get; set; }
    public bool? RequiereSeguimiento { get; set; }
    public DateOnly? FechaSeguimiento { get; set; }
    public string? ArchivoAdjunto { get; set; }
}

public class UpdateComunicacionDto
{
    public string? Asunto { get; set; }
    public string? Contenido { get; set; }
    public DateTime? FechaComunicacion { get; set; }
    public int? DuracionMinutos { get; set; }
    public string? Ubicacion { get; set; }
    public bool? EsImportante { get; set; }
    public bool? RequiereSeguimiento { get; set; }
    public DateOnly? FechaSeguimiento { get; set; }
    public string? EstadoSeguimiento { get; set; }
}
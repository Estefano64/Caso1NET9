using System;
using System.Collections.Generic;

namespace caso2net.Models;

/// <summary>
/// Registro de todas las comunicaciones con clientes
/// </summary>
public partial class ComunicacionesCliente
{
    public int IdComunicacion { get; set; }

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

    public string? EstadoSeguimiento { get; set; }

    public string? ArchivoAdjunto { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ContactosCliente? IdContactoClienteNavigation { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;

    public virtual TiposComunicacion IdTipoComunicacionNavigation { get; set; } = null!;
}

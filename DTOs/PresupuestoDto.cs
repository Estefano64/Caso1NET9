namespace caso2net.DTOs;

public class GastoProyectoDto
{
    public int IdGasto { get; set; }
    public int IdProyecto { get; set; }
    public string NombreProyecto { get; set; } = null!;
    public string Concepto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Monto { get; set; }
    public DateOnly FechaGasto { get; set; }
    public string? Proveedor { get; set; }
    public string? NumeroFactura { get; set; }
    public string CategoriaNombre { get; set; } = null!;
    public int IdRegistradoPor { get; set; }
    public string NombreRegistradoPor { get; set; } = null!;
    public bool? EsAprobado { get; set; }
    public int? IdAprobadoPor { get; set; }
    public string? NombreAprobadoPor { get; set; }
    public DateOnly? FechaAprobacion { get; set; }
    public DateTime? FechaRegistro { get; set; }
}

public class CreateGastoProyectoDto
{
    public int IdProyecto { get; set; }
    public string Concepto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Monto { get; set; }
    public DateOnly FechaGasto { get; set; }
    public string? Proveedor { get; set; }
    public string? NumeroFactura { get; set; }
    public int IdCategoria { get; set; }
    public int IdRegistradoPor { get; set; }
}

public class UpdateGastoProyectoDto
{
    public string? Concepto { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Monto { get; set; }
    public DateOnly? FechaGasto { get; set; }
    public string? Proveedor { get; set; }
    public string? NumeroFactura { get; set; }
    public int? IdCategoria { get; set; }
}

public class ResumenPresupuestoDto
{
    public int IdProyecto { get; set; }
    public string NombreProyecto { get; set; } = null!;
    public decimal PresupuestoEstimado { get; set; }
    public decimal GastoTotal { get; set; }
    public decimal GastoAprobado { get; set; }
    public decimal GastoPendiente { get; set; }
    public decimal SaldoDisponible { get; set; }
    public decimal PorcentajeEjecucion { get; set; }
    public IEnumerable<GastoPorCategoriaDto> GastosPorCategoria { get; set; } = new List<GastoPorCategoriaDto>();
}

public class GastoPorCategoriaDto
{
    public string NombreCategoria { get; set; } = null!;
    public decimal MontoTotal { get; set; }
    public int CantidadGastos { get; set; }
}

public class ComparacionPresupuestoDto
{
    public string Periodo { get; set; } = null!;
    public decimal PresupuestoPlanificado { get; set; }
    public decimal GastoReal { get; set; }
    public decimal Variacion { get; set; }
    public decimal PorcentajeVariacion { get; set; }
}
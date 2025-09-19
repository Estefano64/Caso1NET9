using caso2net.DTOs;

namespace caso2net.Services;

public interface IPresupuestoService
{
    Task<GastoProyectoDto?> GetGastoAsync(int id);
    Task<IEnumerable<GastoProyectoDto>> GetGastosByProyectoAsync(int proyectoId);
    Task<GastoProyectoDto> CreateGastoAsync(CreateGastoProyectoDto dto);
    Task<GastoProyectoDto> UpdateGastoAsync(int id, UpdateGastoProyectoDto dto);
    Task DeleteGastoAsync(int id);
    Task<GastoProyectoDto> AprobarGastoAsync(int gastoId, int aprobadoPorId);
    Task<ResumenPresupuestoDto> GetResumenPresupuestoAsync(int proyectoId);
    Task<IEnumerable<ComparacionPresupuestoDto>> GetComparacionPresupuestoAsync(int proyectoId);
}
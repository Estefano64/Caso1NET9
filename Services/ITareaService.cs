using caso2net.DTOs;

namespace caso2net.Services;

public interface ITareaService
{
    Task<TareaDto?> GetTareaAsync(int id);
    Task<IEnumerable<TareaDto>> GetTareasAsync();
    Task<IEnumerable<TareaDto>> GetTareasByProyectoAsync(int proyectoId);
    Task<IEnumerable<TareaDto>> GetTareasByEmpleadoAsync(int empleadoId);
    Task<TareaDto> CreateTareaAsync(CreateTareaDto dto);
    Task<TareaDto> UpdateTareaAsync(int id, UpdateTareaDto dto);
    Task DeleteTareaAsync(int id);
    Task<TareaDto> AsignarTareaAsync(int tareaId, int empleadoId);
    Task<TareaDto> ActualizarProgreso(int tareaId, decimal porcentaje);
}
using caso2net.DTOs;
using caso2net.Models;

namespace caso2net.Services;

public interface IProyectoService
{
    Task<ProyectoDto?> GetProyectoAsync(int id);
    Task<IEnumerable<ProyectoDto>> GetAllProyectosAsync();
    Task<IEnumerable<ProyectoDto>> GetProyectosByClienteAsync(int clienteId);
    Task<IEnumerable<ProyectoDto>> GetProyectosByEmpleadoAsync(int empleadoId);
    Task<ProyectoDto> CreateProyectoAsync(CreateProyectoDto dto);
    Task<ProyectoDto> UpdateProyectoAsync(int id, UpdateProyectoDto dto);
    Task DeleteProyectoAsync(int id);
    Task<decimal> CalcularPresupuestoRealAsync(int proyectoId);
    Task<decimal> CalcularPorcentajeAvanceAsync(int proyectoId);
}
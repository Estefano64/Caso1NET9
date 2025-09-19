using caso2net.DTOs;

namespace caso2net.Services;

public interface IComunicacionService
{
    Task<ComunicacionDto?> GetComunicacionAsync(int id);
    Task<IEnumerable<ComunicacionDto>> GetComunicacionesAsync();
    Task<IEnumerable<ComunicacionDto>> GetComunicacionesByProyectoAsync(int proyectoId);
    Task<IEnumerable<ComunicacionDto>> GetComunicacionesByClienteAsync(int clienteId);
    Task<ComunicacionDto> CreateComunicacionAsync(CreateComunicacionDto dto);
    Task<ComunicacionDto> UpdateComunicacionAsync(int id, UpdateComunicacionDto dto);
    Task DeleteComunicacionAsync(int id);
}
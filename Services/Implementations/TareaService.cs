using Microsoft.EntityFrameworkCore;
using caso2net.DTOs;
using caso2net.Services; using caso2net.Repositories;
using caso2net.Models;

namespace caso2net.Services.Implementations;

public class TareaService : ITareaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Consultariacaso2Context _context;

    public TareaService(IUnitOfWork unitOfWork, Consultariacaso2Context context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<TareaDto?> GetTareaAsync(int id)
    {
        var tarea = await _context.Tareas
            .Include(t => t.IdProyectoNavigation)
            .Include(t => t.IdAsignadoNavigation)
            .Include(t => t.IdCreadorNavigation)
            .Include(t => t.IdEstadoTareaNavigation)
            .FirstOrDefaultAsync(t => t.IdTarea == id);

        return tarea != null ? MapToDto(tarea) : null;
    }

    public async Task<IEnumerable<TareaDto>> GetTareasAsync()
    {
        var tareas = await _context.Tareas
            .Include(t => t.IdProyectoNavigation)
            .Include(t => t.IdAsignadoNavigation)
            .Include(t => t.IdCreadorNavigation)
            .Include(t => t.IdEstadoTareaNavigation)
            .ToListAsync();

        return tareas.Select(MapToDto);
    }

    public async Task<IEnumerable<TareaDto>> GetTareasByProyectoAsync(int proyectoId)
    {
        var tareas = await _context.Tareas
            .Include(t => t.IdProyectoNavigation)
            .Include(t => t.IdAsignadoNavigation)
            .Include(t => t.IdCreadorNavigation)
            .Include(t => t.IdEstadoTareaNavigation)
            .Where(t => t.IdProyecto == proyectoId)
            .ToListAsync();

        return tareas.Select(MapToDto);
    }

    public async Task<IEnumerable<TareaDto>> GetTareasByEmpleadoAsync(int empleadoId)
    {
        var tareas = await _context.Tareas
            .Include(t => t.IdProyectoNavigation)
            .Include(t => t.IdAsignadoNavigation)
            .Include(t => t.IdCreadorNavigation)
            .Include(t => t.IdEstadoTareaNavigation)
            .Where(t => t.IdAsignado == empleadoId)
            .ToListAsync();

        return tareas.Select(MapToDto);
    }

    public async Task<TareaDto> CreateTareaAsync(CreateTareaDto dto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var tarea = new Tarea
            {
                NombreTarea = dto.NombreTarea,
                Descripcion = dto.Descripcion,
                IdProyecto = dto.IdProyecto,
                IdAsignado = dto.IdAsignado,
                IdCreador = dto.IdCreador,
                IdEstadoTarea = dto.IdEstadoTarea,
                FechaInicioEstimada = dto.FechaInicioEstimada,
                FechaFinEstimada = dto.FechaFinEstimada,
                HorasEstimadas = dto.HorasEstimadas ?? 0,
                HorasTrabajadas = 0,
                PorcentajeCompletado = 0,
                Prioridad = dto.Prioridad ?? "media",
                Notas = dto.Notas,
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now),
                FechaActualizacion = DateTime.Now
            };

            await _unitOfWork.Tareas.AddAsync(tarea);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return await GetTareaAsync(tarea.IdTarea) ?? throw new InvalidOperationException("Error al crear tarea");
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<TareaDto> UpdateTareaAsync(int id, UpdateTareaDto dto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                throw new KeyNotFoundException($"Tarea con ID {id} no encontrada");

            if (!string.IsNullOrEmpty(dto.NombreTarea))
                tarea.NombreTarea = dto.NombreTarea;

            if (dto.Descripcion != null)
                tarea.Descripcion = dto.Descripcion;

            if (dto.IdAsignado.HasValue)
                tarea.IdAsignado = dto.IdAsignado;

            if (dto.IdEstadoTarea.HasValue)
                tarea.IdEstadoTarea = dto.IdEstadoTarea.Value;

            if (dto.FechaInicioEstimada.HasValue)
                tarea.FechaInicioEstimada = dto.FechaInicioEstimada;

            if (dto.FechaFinEstimada.HasValue)
                tarea.FechaFinEstimada = dto.FechaFinEstimada;

            if (dto.FechaInicioReal.HasValue)
                tarea.FechaInicioReal = dto.FechaInicioReal;

            if (dto.FechaFinReal.HasValue)
                tarea.FechaFinReal = dto.FechaFinReal;

            if (dto.HorasEstimadas.HasValue)
                tarea.HorasEstimadas = dto.HorasEstimadas;

            if (dto.HorasTrabajadas.HasValue)
                tarea.HorasTrabajadas = dto.HorasTrabajadas;

            if (dto.PorcentajeCompletado.HasValue)
                tarea.PorcentajeCompletado = dto.PorcentajeCompletado;

            if (!string.IsNullOrEmpty(dto.Prioridad))
                tarea.Prioridad = dto.Prioridad;

            if (dto.Notas != null)
                tarea.Notas = dto.Notas;

            tarea.FechaActualizacion = DateTime.Now;

            await _unitOfWork.Tareas.UpdateAsync(tarea);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return await GetTareaAsync(id) ?? throw new InvalidOperationException("Error al actualizar tarea");
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task DeleteTareaAsync(int id)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                throw new KeyNotFoundException($"Tarea con ID {id} no encontrada");

            await _unitOfWork.Tareas.DeleteAsync(tarea);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<TareaDto> AsignarTareaAsync(int tareaId, int empleadoId)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var tarea = await _context.Tareas.FindAsync(tareaId);
            if (tarea == null)
                throw new KeyNotFoundException($"Tarea con ID {tareaId} no encontrada");

            var empleado = await _context.Empleados.FindAsync(empleadoId);
            if (empleado == null)
                throw new KeyNotFoundException($"Empleado con ID {empleadoId} no encontrado");

            tarea.IdAsignado = empleadoId;
            tarea.FechaActualizacion = DateTime.Now;

            await _unitOfWork.Tareas.UpdateAsync(tarea);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return await GetTareaAsync(tareaId) ?? throw new InvalidOperationException("Error al asignar tarea");
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<TareaDto> ActualizarProgreso(int tareaId, decimal porcentaje)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var tarea = await _context.Tareas.FindAsync(tareaId);
            if (tarea == null)
                throw new KeyNotFoundException($"Tarea con ID {tareaId} no encontrada");

            tarea.PorcentajeCompletado = Math.Max(0, Math.Min(100, porcentaje));
            tarea.FechaActualizacion = DateTime.Now;

            if (porcentaje >= 100)
            {
                var estadoCompletado = await _context.EstadosTareas
                    .FirstOrDefaultAsync(e => e.NombreEstado == "Completada");

                if (estadoCompletado != null)
                {
                    tarea.IdEstadoTarea = estadoCompletado.IdEstadoTarea;
                    tarea.FechaFinReal = DateOnly.FromDateTime(DateTime.Now);
                }
            }

            await _unitOfWork.Tareas.UpdateAsync(tarea);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return await GetTareaAsync(tareaId) ?? throw new InvalidOperationException("Error al actualizar progreso");
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    private static TareaDto MapToDto(Tarea tarea)
    {
        return new TareaDto
        {
            IdTarea = tarea.IdTarea,
            NombreTarea = tarea.NombreTarea,
            Descripcion = tarea.Descripcion,
            IdProyecto = tarea.IdProyecto,
            NombreProyecto = tarea.IdProyectoNavigation.NombreProyecto,
            IdAsignado = tarea.IdAsignado,
            NombreAsignado = tarea.IdAsignadoNavigation != null
                ? $"{tarea.IdAsignadoNavigation.Nombres} {tarea.IdAsignadoNavigation.Apellidos}"
                : null,
            IdCreador = tarea.IdCreador,
            NombreCreador = $"{tarea.IdCreadorNavigation.Nombres} {tarea.IdCreadorNavigation.Apellidos}",
            EstadoTarea = tarea.IdEstadoTareaNavigation.NombreEstado,
            FechaInicioEstimada = tarea.FechaInicioEstimada,
            FechaFinEstimada = tarea.FechaFinEstimada,
            FechaInicioReal = tarea.FechaInicioReal,
            FechaFinReal = tarea.FechaFinReal,
            HorasEstimadas = tarea.HorasEstimadas,
            HorasTrabajadas = tarea.HorasTrabajadas,
            PorcentajeCompletado = tarea.PorcentajeCompletado,
            Prioridad = tarea.Prioridad,
            Notas = tarea.Notas,
            FechaCreacion = tarea.FechaCreacion,
            FechaActualizacion = tarea.FechaActualizacion
        };
    }
}
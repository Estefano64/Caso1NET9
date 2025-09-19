using Microsoft.EntityFrameworkCore;
using caso2net.DTOs;
using caso2net.Services; using caso2net.Repositories;
using caso2net.Models;

namespace caso2net.Services.Implementations;

public class ProyectoService : IProyectoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Consultariacaso2Context _context;

    public ProyectoService(IUnitOfWork unitOfWork, Consultariacaso2Context context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<ProyectoDto?> GetProyectoAsync(int id)
    {
        var proyecto = await _context.Proyectos
            .Include(p => p.IdClienteNavigation)
            .Include(p => p.IdResponsableNavigation)
            .Include(p => p.IdEstadoNavigation)
            .FirstOrDefaultAsync(p => p.IdProyecto == id);

        if (proyecto == null)
            return null;

        return MapToDto(proyecto);
    }

    public async Task<IEnumerable<ProyectoDto>> GetAllProyectosAsync()
    {
        var proyectos = await _context.Proyectos
            .Include(p => p.IdClienteNavigation)
            .Include(p => p.IdResponsableNavigation)
            .Include(p => p.IdEstadoNavigation)
            .ToListAsync();

        return proyectos.Select(MapToDto);
    }

    public async Task<IEnumerable<ProyectoDto>> GetProyectosByClienteAsync(int clienteId)
    {
        var proyectos = await _context.Proyectos
            .Include(p => p.IdClienteNavigation)
            .Include(p => p.IdResponsableNavigation)
            .Include(p => p.IdEstadoNavigation)
            .Where(p => p.IdCliente == clienteId)
            .ToListAsync();

        return proyectos.Select(MapToDto);
    }

    public async Task<IEnumerable<ProyectoDto>> GetProyectosByEmpleadoAsync(int empleadoId)
    {
        var proyectos = await _context.Proyectos
            .Include(p => p.IdClienteNavigation)
            .Include(p => p.IdResponsableNavigation)
            .Include(p => p.IdEstadoNavigation)
            .Where(p => p.IdResponsable == empleadoId || p.ProyectoEmpleados.Any(pe => pe.IdEmpleado == empleadoId && pe.Activo == true))
            .ToListAsync();

        return proyectos.Select(MapToDto);
    }

    public async Task<ProyectoDto> CreateProyectoAsync(CreateProyectoDto dto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var estadoInicial = await _context.EstadosProyectos
                .FirstOrDefaultAsync(e => e.NombreEstado == "Planificación");

            var proyecto = new Proyecto
            {
                CodigoProyecto = dto.CodigoProyecto,
                NombreProyecto = dto.NombreProyecto,
                Descripcion = dto.Descripcion,
                Objetivos = dto.Objetivos,
                IdCliente = dto.IdCliente,
                IdTipoProyecto = dto.IdTipoProyecto,
                IdResponsable = dto.IdResponsable,
                IdEstado = estadoInicial?.IdEstado ?? 1,
                FechaInicio = dto.FechaInicio,
                FechaFinEstimada = dto.FechaFinEstimada,
                PresupuestoEstimado = dto.PresupuestoEstimado,
                Prioridad = dto.Prioridad ?? "media",
                GastoReal = 0,
                PorcentajeAvance = 0,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
            };

            await _unitOfWork.Proyectos.AddAsync(proyecto);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return await GetProyectoAsync(proyecto.IdProyecto) ?? throw new InvalidOperationException("Error al crear proyecto");
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<ProyectoDto> UpdateProyectoAsync(int id, UpdateProyectoDto dto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
                throw new KeyNotFoundException($"Proyecto con ID {id} no encontrado");

            if (!string.IsNullOrEmpty(dto.NombreProyecto))
                proyecto.NombreProyecto = dto.NombreProyecto;

            if (dto.Descripcion != null)
                proyecto.Descripcion = dto.Descripcion;

            if (dto.Objetivos != null)
                proyecto.Objetivos = dto.Objetivos;

            if (dto.IdResponsable.HasValue)
                proyecto.IdResponsable = dto.IdResponsable.Value;

            if (dto.IdEstado.HasValue)
                proyecto.IdEstado = dto.IdEstado.Value;

            if (dto.FechaFinEstimada.HasValue)
                proyecto.FechaFinEstimada = dto.FechaFinEstimada;

            if (dto.FechaFinReal.HasValue)
                proyecto.FechaFinReal = dto.FechaFinReal;

            if (dto.PresupuestoEstimado.HasValue)
                proyecto.PresupuestoEstimado = dto.PresupuestoEstimado.Value;

            if (dto.PorcentajeAvance.HasValue)
                proyecto.PorcentajeAvance = dto.PorcentajeAvance;

            if (!string.IsNullOrEmpty(dto.Prioridad))
                proyecto.Prioridad = dto.Prioridad;

            proyecto.FechaActualizacion = DateTime.Now;

            await _unitOfWork.Proyectos.UpdateAsync(proyecto);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return await GetProyectoAsync(id) ?? throw new InvalidOperationException("Error al actualizar proyecto");
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task DeleteProyectoAsync(int id)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
                throw new KeyNotFoundException($"Proyecto con ID {id} no encontrado");

            await _unitOfWork.Proyectos.DeleteAsync(proyecto);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<decimal> CalcularPresupuestoRealAsync(int proyectoId)
    {
        var gastoTotal = await _context.GastosProyectos
            .Where(g => g.IdProyecto == proyectoId && g.EsAprobado == true)
            .SumAsync(g => g.Monto);

        var proyecto = await _context.Proyectos.FindAsync(proyectoId);
        if (proyecto != null)
        {
            proyecto.GastoReal = gastoTotal;
            proyecto.FechaActualizacion = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        return gastoTotal;
    }

    public async Task<decimal> CalcularPorcentajeAvanceAsync(int proyectoId)
    {
        var hitos = await _context.HitosProyectos
            .Where(h => h.IdProyecto == proyectoId)
            .ToListAsync();

        if (!hitos.Any())
            return 0;

        var pesoTotal = hitos.Sum(h => h.PorcentajePeso ?? 0);
        var pesoCompletado = hitos.Where(h => h.EsCompletado == true).Sum(h => h.PorcentajePeso ?? 0);

        var porcentaje = pesoTotal > 0 ? (decimal)((pesoCompletado / pesoTotal) * 100) : 0;

        var proyecto = await _context.Proyectos.FindAsync(proyectoId);
        if (proyecto != null)
        {
            proyecto.PorcentajeAvance = porcentaje;
            proyecto.FechaActualizacion = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        return porcentaje;
    }

    private static ProyectoDto MapToDto(Proyecto proyecto)
    {
        return new ProyectoDto
        {
            IdProyecto = proyecto.IdProyecto,
            CodigoProyecto = proyecto.CodigoProyecto,
            NombreProyecto = proyecto.NombreProyecto,
            Descripcion = proyecto.Descripcion,
            Objetivos = proyecto.Objetivos,
            IdCliente = proyecto.IdCliente,
            NombreCliente = proyecto.IdClienteNavigation.NombreEmpresa,
            IdResponsable = proyecto.IdResponsable,
            NombreResponsable = $"{proyecto.IdResponsableNavigation.Nombres} {proyecto.IdResponsableNavigation.Apellidos}",
            EstadoProyecto = proyecto.IdEstadoNavigation.NombreEstado,
            FechaInicio = proyecto.FechaInicio,
            FechaFinEstimada = proyecto.FechaFinEstimada,
            FechaFinReal = proyecto.FechaFinReal,
            PresupuestoEstimado = proyecto.PresupuestoEstimado,
            GastoReal = proyecto.GastoReal,
            PorcentajeAvance = proyecto.PorcentajeAvance,
            Prioridad = proyecto.Prioridad,
            FechaCreacion = proyecto.FechaCreacion,
            FechaActualizacion = proyecto.FechaActualizacion
        };
    }
}
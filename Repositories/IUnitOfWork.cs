using caso2net.Models;

namespace caso2net.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<Proyecto> Proyectos { get; }
    IRepository<Cliente> Clientes { get; }
    IRepository<Empleado> Empleados { get; }
    IRepository<Tarea> Tareas { get; }
    IRepository<GastosProyecto> GastosProyectos { get; }
    IRepository<ComunicacionesCliente> ComunicacionesClientes { get; }
    IRepository<HitosProyecto> HitosProyectos { get; }
    IRepository<ProyectoEmpleado> ProyectoEmpleados { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
using Microsoft.EntityFrameworkCore.Storage;
using caso2net.Models;

namespace caso2net.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly Consultariacaso2Context _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(Consultariacaso2Context context)
    {
        _context = context;
        Proyectos = new Repository<Proyecto>(_context);
        Clientes = new Repository<Cliente>(_context);
        Empleados = new Repository<Empleado>(_context);
        Tareas = new Repository<Tarea>(_context);
        GastosProyectos = new Repository<GastosProyecto>(_context);
        ComunicacionesClientes = new Repository<ComunicacionesCliente>(_context);
        HitosProyectos = new Repository<HitosProyecto>(_context);
        ProyectoEmpleados = new Repository<ProyectoEmpleado>(_context);
    }

    public IRepository<Proyecto> Proyectos { get; }
    public IRepository<Cliente> Clientes { get; }
    public IRepository<Empleado> Empleados { get; }
    public IRepository<Tarea> Tareas { get; }
    public IRepository<GastosProyecto> GastosProyectos { get; }
    public IRepository<ComunicacionesCliente> ComunicacionesClientes { get; }
    public IRepository<HitosProyecto> HitosProyectos { get; }
    public IRepository<ProyectoEmpleado> ProyectoEmpleados { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
using Microsoft.AspNetCore.Mvc;
using caso2net.DTOs;
using caso2net.Services;

namespace caso2net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly IProyectoService _proyectoService;

    public ProyectosController(IProyectoService proyectoService)
    {
        _proyectoService = proyectoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProyectoDto>>> GetProyectos()
    {
        try
        {
            var proyectos = await _proyectoService.GetAllProyectosAsync();
            return Ok(proyectos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProyectoDto>> GetProyecto(int id)
    {
        try
        {
            var proyecto = await _proyectoService.GetProyectoAsync(id);
            if (proyecto == null)
                return NotFound(new { message = $"Proyecto con ID {id} no encontrado" });

            return Ok(proyecto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<ActionResult<IEnumerable<ProyectoDto>>> GetProyectosByCliente(int clienteId)
    {
        try
        {
            var proyectos = await _proyectoService.GetProyectosByClienteAsync(clienteId);
            return Ok(proyectos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("empleado/{empleadoId}")]
    public async Task<ActionResult<IEnumerable<ProyectoDto>>> GetProyectosByEmpleado(int empleadoId)
    {
        try
        {
            var proyectos = await _proyectoService.GetProyectosByEmpleadoAsync(empleadoId);
            return Ok(proyectos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProyectoDto>> CreateProyecto(CreateProyectoDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var proyecto = await _proyectoService.CreateProyectoAsync(dto);
            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.IdProyecto }, proyecto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProyectoDto>> UpdateProyecto(int id, UpdateProyectoDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var proyecto = await _proyectoService.UpdateProyectoAsync(id, dto);
            return Ok(proyecto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProyecto(int id)
    {
        try
        {
            await _proyectoService.DeleteProyectoAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}/presupuesto-real")]
    public async Task<ActionResult<decimal>> GetPresupuestoReal(int id)
    {
        try
        {
            var presupuesto = await _proyectoService.CalcularPresupuestoRealAsync(id);
            return Ok(new { proyectoId = id, presupuestoReal = presupuesto });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}/porcentaje-avance")]
    public async Task<ActionResult<decimal>> GetPorcentajeAvance(int id)
    {
        try
        {
            var porcentaje = await _proyectoService.CalcularPorcentajeAvanceAsync(id);
            return Ok(new { proyectoId = id, porcentajeAvance = porcentaje });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}
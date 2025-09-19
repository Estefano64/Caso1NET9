using Microsoft.AspNetCore.Mvc;
using caso2net.DTOs;
using caso2net.Services;

namespace caso2net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly ITareaService _tareaService;

    public TareasController(ITareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TareaDto>>> GetTareas()
    {
        try
        {
            var tareas = await _tareaService.GetTareasAsync();
            return Ok(tareas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TareaDto>> GetTarea(int id)
    {
        try
        {
            var tarea = await _tareaService.GetTareaAsync(id);
            if (tarea == null)
                return NotFound(new { message = $"Tarea con ID {id} no encontrada" });

            return Ok(tarea);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("proyecto/{proyectoId}")]
    public async Task<ActionResult<IEnumerable<TareaDto>>> GetTareasByProyecto(int proyectoId)
    {
        try
        {
            var tareas = await _tareaService.GetTareasByProyectoAsync(proyectoId);
            return Ok(tareas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("empleado/{empleadoId}")]
    public async Task<ActionResult<IEnumerable<TareaDto>>> GetTareasByEmpleado(int empleadoId)
    {
        try
        {
            var tareas = await _tareaService.GetTareasByEmpleadoAsync(empleadoId);
            return Ok(tareas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<TareaDto>> CreateTarea(CreateTareaDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tarea = await _tareaService.CreateTareaAsync(dto);
            return CreatedAtAction(nameof(GetTarea), new { id = tarea.IdTarea }, tarea);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TareaDto>> UpdateTarea(int id, UpdateTareaDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tarea = await _tareaService.UpdateTareaAsync(id, dto);
            return Ok(tarea);
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

    [HttpPut("{id}/asignar/{empleadoId}")]
    public async Task<ActionResult<TareaDto>> AsignarTarea(int id, int empleadoId)
    {
        try
        {
            var tarea = await _tareaService.AsignarTareaAsync(id, empleadoId);
            return Ok(tarea);
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

    [HttpPut("{id}/progreso")]
    public async Task<ActionResult<TareaDto>> ActualizarProgreso(int id, [FromBody] decimal porcentaje)
    {
        try
        {
            var tarea = await _tareaService.ActualizarProgreso(id, porcentaje);
            return Ok(tarea);
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
    public async Task<IActionResult> DeleteTarea(int id)
    {
        try
        {
            await _tareaService.DeleteTareaAsync(id);
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
}
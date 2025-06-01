using api.Application.Services;
using api.Domain.Entities;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _service;

    public TaskController(TaskService service)
    {
        _service = service;
    }

    /// <summary>
    /// Funcion utilizada para la creacion de tareas
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] TaskModel model)
    {
        var task = await _service.CreateAsync(model);
        return Ok(task);
    }

    /// <summary>
    /// Funcion utilizada para la visualizacion de informacion segun estado indicado.
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    [HttpGet("List")]
    public async Task<IActionResult> List([FromQuery] string state = "Pendiente")
    {
        var tasks = await _service.ListAsync(state);
        return Ok(tasks);
    }

    /// <summary>
    /// Funcion utilizada para la modificacion del estado a completado
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Complete")]
    public async Task<IActionResult> Complete([FromQuery] Guid id)
    {
        var task = await _service.CompleteTaskAsync(id);
        return Ok(task);
    }

    /// <summary>
    /// Funcion utilizada para la eliminacion de una tarea 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
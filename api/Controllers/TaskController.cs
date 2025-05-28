using api.Application.Services;
using api.Domain.Entities;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[action]")]
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

    [HttpPost]
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
    [HttpGet("{state}")]
    public async Task<IActionResult> List(string state)
    {
        var tasks = await _service.ListAsync(state);
        return Ok(tasks);
    }

    /// <summary>
    /// Funcion utilizada para la modificacion del estado a completado
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Complete(Guid id)
    {
        var task = await _service.CompleteTaskAsync(id);
        return Ok(task);
    }

    /// <summary>
    /// Funcion utilizada para la eliminacion de una tarea 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
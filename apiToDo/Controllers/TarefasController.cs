using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        // Instância da classe Tasks
        private readonly Tasks _tasks;

        public TarefasController()
        {
            _tasks = new Tasks();
        }

        // Rota para listar todas as tarefas
        [HttpGet("tarefas")]
        public ActionResult<List<TaskDTO>> GetTasks()
        {
            try
            {
                var lista = _tasks.GetTasks();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }

        // Rota para criar uma nova tarefa
        [HttpPost("tarefas")]
        public ActionResult<List<TaskDTO>> CreateTask([FromBody] TaskDTO request)
        {
            try
            {
                _tasks.CreateTask(request);
                var lista = _tasks.GetTasks();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }

        // Rota para deletar uma tarefa
        [HttpDelete("tarefas/{idTask}")]
        public ActionResult<List<TaskDTO>> DeleteTask(int idTask)
        {
            try
            {
                _tasks.DeleteTask(idTask);
                var lista = _tasks.GetTasks();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }

        // Rota para atualizar uma tarefa
        [HttpPut("tarefas")]
        public ActionResult<List<TaskDTO>> UpdateTask([FromBody] TaskDTO request)
        {
            try
            {
                _tasks.UpdateTask(request);
                var lista = _tasks.GetTasks();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }
    }
}

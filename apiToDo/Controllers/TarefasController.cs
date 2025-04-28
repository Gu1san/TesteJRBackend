using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        // Instância da classe Tarefas
        private readonly Tarefas _tarefas;

        public TarefasController()
        {
            _tarefas = new Tarefas();
        }

        [Authorize]
        [HttpPost("LstTarefas")]
        public ActionResult<List<TaskDTO>> LstTarefas()
        {
            try
            {
                var lista = _tarefas.LstTarefas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult<List<TaskDTO>> InserirTarefas([FromBody] TaskDTO request)
        {
            try
            {
                _tarefas.InserirTarefa(request);
                var lista = _tarefas.LstTarefas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult<List<TaskDTO>> DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                _tarefas.DeletarTarefa(ID_TAREFA);
                var lista = _tarefas.LstTarefas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }
    }
}

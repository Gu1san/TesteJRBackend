using apiToDo.DTO;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tasks
    {
        private static List<TaskDTO> _tasks = new()
        {
            new() { ID_TASK = 1, DS_TASK = "Fazer Compras" },
            new() { ID_TASK = 2, DS_TASK = "Fazer Atividade Faculdade" },
            new() { ID_TASK = 3, DS_TASK = "Subir Projeto de Teste no GitHub" }
        };

        public List<TaskDTO> GetTasks()
        {
            return _tasks;
        }

        public List<TaskDTO> CreateTask(TaskDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.DS_TASK))
                throw new ArgumentException("A descrição da tarefa não pode ser vazia.");

            if(SearchTaskById(request.ID_TASK) != null)
                throw new ArgumentException($"A tarefa com ID {request.ID_TASK} já existe.");

            _tasks.Add(request);
            return _tasks;
        }
         
        public List<TaskDTO> DeleteTask(int idTask)
        {
            // Busca a tarefa pelo ID
            var tarefa = SearchTaskById(idTask);

            // Remove a tarefa da lista e retorna a lista atualizada
            _tasks.Remove(tarefa);
            return _tasks;
        }

        public List<TaskDTO> UpdateTask(TaskDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.DS_TASK))
                throw new ArgumentException("A descrição da tarefa não pode ser vazia.");

            var tarefa = SearchTaskById(request.ID_TASK);

            tarefa.DS_TASK = request.DS_TASK;
            return _tasks;
        }

        public TaskDTO SearchTaskById(int idTask)
        {
            // Verifica se o ID da tarefa é válido
            var tarefa = _tasks.FirstOrDefault(t => t.ID_TASK == idTask);

            // Se a tarefa não for encontrada, lança uma exceção
            if (tarefa == null)
                throw new Exception($"Task com ID {idTask} não encontrada.");

            return tarefa;
        }
    }
}

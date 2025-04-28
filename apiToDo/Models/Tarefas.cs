using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private static List<TarefaDTO> _tarefas = new()
        {
            new() { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new() { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade" },
            new() { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        public List<TarefaDTO> LstTarefas()
        {
            return _tarefas;
        }

        public List<TarefaDTO> InserirTarefa(TarefaDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            _tarefas.Add(request);
            return _tarefas;
        }

        public List<TarefaDTO> DeletarTarefa(int idTarefa)
        {
            //Busca a tarefa pelo ID
            var tarefa = BuscarTarefaPorId(idTarefa);

            //Remove a tarefa da lista e retorna a lista atualizada
            _tarefas.Remove(tarefa);
            return _tarefas;
        }

        public List<TarefaDTO> AtualizarTarefa(TarefaDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var tarefa = _tarefas.FirstOrDefault(t => t.ID_TAREFA == request.ID_TAREFA);
            if (tarefa == null)
                throw new Exception($"Tarefa com ID {request.ID_TAREFA} não encontrada.");

            tarefa.DS_TAREFA = request.DS_TAREFA;
            return _tarefas;
        }

        public TarefaDTO BuscarTarefaPorId(int idTarefa)
        {
            //Verifica se o ID da tarefa é válido
            var tarefa = _tarefas.FirstOrDefault(t => t.ID_TAREFA == idTarefa);

            //Se a tarefa não for encontrada, lança uma exceção
            if (tarefa == null)
                throw new Exception($"Tarefa com ID {idTarefa} não encontrada.");

            return tarefa;
        }
    }
}

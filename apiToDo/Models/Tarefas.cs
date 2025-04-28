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

        public void InserirTarefa(TarefaDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            _tarefas.Add(request);
        }

        public void DeletarTarefa(int idTarefa)
        {
            try
            {
                // Busca a tarefa pelo ID
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == idTarefa);

                // Verifica se encontrou
                if (tarefa == null)
                    throw new KeyNotFoundException($"Tarefa com ID {idTarefa} não encontrada.");

                // Remove a tarefa encontrada
                _tarefas.Remove(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar tarefa: {ex.Message}", ex);
            }
        }

        public void AtualizarTarefa(TarefaDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == request.ID_TAREFA);

            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com ID {request.ID_TAREFA} não encontrada.");

            tarefa.DS_TAREFA = request.DS_TAREFA;
        }

        public TarefaDTO BuscarTarefaPorId(int idTarefa)
        {
            var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == idTarefa);

            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com ID {idTarefa} não encontrada.");

            return tarefa;
        }
    }
}

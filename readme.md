# 📋 Desafio API - ToDo List

Este projeto é uma API de lista de tarefas (**ToDo List**) desenvolvida em **.NET**.  
A API permite listar, adicionar, atualizar e remover tarefas de uma lista em memória.

---

## 🚀 Como executar

1. **Clone o repositório**:
```bash
   git clone https://github.com/seu-usuario/api-todolist.git
```
2. **Abra o projeto no Visual Studio 2022** (ou mais recente).

3. **Restaure os pacotes**:

   dotnet restore

4. **Execute a aplicação**:
```bash
   dotnet run
```
---

## 🛠️ Tecnologias utilizadas

- .NET 5
- ASP.NET Core Web API
- Swagger (Swashbuckle)

---

## 📚 Funcionalidades da API

- Get: Lista todas as tarefas cadastradas.

https://github.com/user-attachments/assets/b3529612-50eb-4225-a631-5a77709f75a1

- Post: Insere uma nova tarefa.

https://github.com/user-attachments/assets/daf51dae-da45-4da2-988a-44ed8d1f697a

https://github.com/user-attachments/assets/d35145e9-662e-44da-8e83-fb6c9a04ef89

- Delete: Deleta uma tarefa específica pelo ID.

https://github.com/user-attachments/assets/78b4db85-be97-4310-b114-dfab063a6560

- Put: Atualiza a descrição de uma tarefa

https://github.com/user-attachments/assets/73320c92-e680-464c-b4a6-e3aebcdaaa89

---

## 🧩 Estrutura básica

### DTO

A classe `TaskDTO` representa o modelo de dados da tarefa, com os seguintes atributos:

- `int ID_TASK`
- `string DS_TASK`

### Model

A classe `Tasks` é responsável por gerenciar a lista de tarefas em memória, com métodos para:

- Buscar todas as tarefas
- Criar uma tarefa
- Atualizar uma tarefa
- Deletar uma tarefa

# API de Gerenciamento de Tarefas

Esta é uma API RESTful desenvolvida com .NET para gerenciar tarefas. Ela permite criar, listar, atualizar e excluir tarefas, com estrutura organizada em camadas e uso de Entity Framework com banco de dados MySQL.

## 📁 Estrutura do Projeto

- `Controllers/` – Endpoints HTTP da aplicação
- `DTO/` – Objetos de transferência de dados
- `Models/` – Representações das entidades do sistema
- `Services/` – Regras de negócio e lógica da aplicação
- `Database/` – Contexto do Entity Framework
- `Migrations/` – Migrations do banco de dados

## 🚀 Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core
- MySQL
- Swagger (documentação automática)

## 📦 Instalação

1. **Clone o repositório**
```bash
git clone https://github.com/seu-usuario/API_Tarefas.git
```

2. **Configure o banco de dados**

Atualize a string de conexão em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=tarefasdb;user=root;password=sua_senha"
}
```

3. **Rode as migrations**

```bash
dotnet ef database update
```

4. **Inicie a aplicação**

```bash
dotnet run
```

A API será disponibilizada em: `https://localhost:5001` ou `http://localhost:5000`

## 🧪 Documentação Swagger

Acesse a documentação interativa da API através do Swagger:

```
https://localhost:5001/swagger
```

## 🔄 Endpoints

| Método | Rota              | Descrição               |
|--------|-------------------|-------------------------|
| GET    | /api/tarefas      | Lista todas as tarefas  |
| GET    | /api/tarefas/{id} | Retorna uma tarefa      |
| POST   | /api/tarefas      | Cria uma nova tarefa    |
| PUT    | /api/tarefas/{id} | Atualiza uma tarefa     |
| DELETE | /api/tarefas/{id} | Remove uma tarefa       |

## 📄 Licença

Este projeto é de uso livre para fins educacionais.

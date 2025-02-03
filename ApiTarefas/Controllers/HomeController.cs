using ApiTarefas.ModelVielws;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers; 

[ApiController] // Define que a classe é um Controller
[Route("/")] // Define a rota do Controller

// HomeController herda de ControllerBase para ter acesso a métodos de resposta
public class HomeController : ControllerBase
{
    [HttpGet] // Define que o método responde a requisições GET
    public HomeView Index()
    {
        return new HomeView()
        {
            Mensagem = "Bem-vindo a API de Tarefas",
            Documentacao = "Em breve documentação"
        };
    }
}
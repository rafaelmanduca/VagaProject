using Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vaga.Models;

namespace Vaga.Controllers
{
    public class VagasController : Controller
    {
        private readonly ILogger<VagasController> _logger;

        public VagasController(ILogger<VagasController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<VagaEstacionamento> vagas = new List<VagaEstacionamento>
            {
                   new VagaEstacionamento(1,1,"Carro",true,DateTime.Now,DateTime.Now),
                   new VagaEstacionamento(2,2,"Moto",false,DateTime.Now,DateTime.Now),
                   new VagaEstacionamento(3,3,"Carro",true,DateTime.Now,DateTime.Now),
                   new VagaEstacionamento(4,4,"Moto",true,DateTime.Now,DateTime.Now)
                };
               
            var vagasDisponiveis = vagas.Where(x => x.Status).ToList();
            
            return View(vagasDisponiveis);
        }

        public IActionResult Cadastro(int id) 
        {
            var vaga = new VagaEstacionamento (id, 0, "",true, DateTime.Now, DateTime.Now);
            return View(vaga);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

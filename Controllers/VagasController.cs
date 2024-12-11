using Estacionamento.Data;
using Estacionamento.Models;
using Estacionamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vaga.Models;

namespace Vaga.Controllers
{
    public class VagasController : Controller
    {
        private readonly ILogger<VagasController> _logger;

        private readonly VagaService _service;

        public VagasController(ILogger<VagasController> logger, VagaService service)
        {
            _logger = logger;
            _service = service;
        }
        
        

        public IActionResult Index()
        {
            
            List<VagaEstacionamento> vagas = _service.FindAll();
            return View(vagas);
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

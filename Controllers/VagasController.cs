using Estacionamento.Data;
using Estacionamento.Models;
using Estacionamento.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            if (vagas == null || !vagas.Any())
            {
                ViewBag.Mensagem = "Nenhuma vaga cadastrada.";
            }
            return View(vagas);
        }


        

        [HttpPost]
        public IActionResult Cadastro(VagaEstacionamento vaga)
        {
            if (ModelState.IsValid)
            {
                _service.Add(vaga);
                return RedirectToAction(nameof(Index));
            }
            var vagasExistentes = _service.FindAll().Select(v => v.NumeroVaga).ToList();
            ViewBag.NumerosDisponiveis = Enumerable.Range(1, 20).Except(vagasExistentes).ToList();
            return View(vaga);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vaga = _service.FindById(id);
            if (vaga == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }
            return View(vaga);
        }

        [HttpPost]
        public IActionResult Edit(VagaEstacionamento vaga)
        {
            if (ModelState.IsValid)
            {
                _service.Update(vaga);
                return RedirectToAction(nameof(Index));
            }
            return View(vaga);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vaga = _service.FindById(id);
            if (vaga == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }
            return View(vaga);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var vaga = _service.FindById(id);
            if (vaga == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }

            _service.Remove(vaga);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var vaga = _service.FindById(id);
            if (vaga == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }
            return View(vaga);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

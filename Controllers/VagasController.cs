using Parking.Data;
using Parking.Models;
using Parking.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Parking.Controllers
{
    public class ParkingSpotsController : Controller
    {
        private readonly ILogger<ParkingSpotsController> _logger;
        private readonly ParkingSpotService _service;

        public ParkingSpotsController(ILogger<ParkingSpotsController> logger, ParkingSpotService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            List<ParkingSpot> parkingSpots = _service.FindAll();
            if (parkingSpots == null || !parkingSpots.Any())
            {
                ViewBag.Message = "Nenhuma vaga encontrada.";
            }
            return View(parkingSpots);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                _service.Add(parkingSpot);
                return RedirectToAction(nameof(Index));
            }
            var existingSpots = _service.FindAll().Select(v => v.SpotNumber).ToList();
            ViewBag.AvailableNumbers = Enumerable.Range(1, 20).Except(existingSpots).ToList();
            return View(parkingSpot);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var parkingSpot = _service.FindById(id);
            if (parkingSpot == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }
            return View(parkingSpot);
        }

        [HttpPost]
        public IActionResult Edit(ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                _service.Update(parkingSpot);
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSpot);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var parkingSpot = _service.FindById(id);
            if (parkingSpot == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }
            return View(parkingSpot);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var parkingSpot = _service.FindById(id);
            if (parkingSpot == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }

            _service.Remove(parkingSpot);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var parkingSpot = _service.FindById(id);
            if (parkingSpot == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vaga não encontrada" });
            }
            return View(parkingSpot);
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

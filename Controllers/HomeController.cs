using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExercicioMVC.Models; // Corrigido aqui
using Microsoft.Extensions.Logging;
using WebApplication3.Models;

namespace ExercicioMVC.Controllers // Corrigido aqui
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Aluno"); // Redireciona para o CRUD
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

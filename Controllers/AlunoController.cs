using ExercicioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioMVC.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ILogger<AlunoController> _logger;
        private static List<Aluno> alunos = new List<Aluno>();
        private static int proximoId = 1;

        public AlunoController(ILogger<AlunoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(alunos); // alunos deve ser uma lista estática ou vinda de banco
        }


        //public IActionResult Index()
        //{
        //    return View(alunos); // ← Isso é OBRIGATÓRIO!
        //}

        public IActionResult Create() => View();
              

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.Id = proximoId++;
                alunos.Add(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public IActionResult Edit(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            return aluno == null ? NotFound() : View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Aluno aluno)
        {
            var existente = alunos.FirstOrDefault(a => a.Id == id);
            if (existente == null) return NotFound();

            if (ModelState.IsValid)
            {
                existente.Nome = aluno.Nome;
                existente.Idade = aluno.Idade;
                existente.Turma = aluno.Turma;
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public IActionResult Details(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            return aluno == null ? NotFound() : View(aluno);
        }

        public IActionResult Delete(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            return aluno == null ? NotFound() : View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
                alunos.Remove(aluno);

            return RedirectToAction(nameof(Index));
        }

    }
}
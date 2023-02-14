using Mesocycle_Maker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mesocycle_Maker.Controllers
{
    public class ExercisePerMesoController : Controller
    {
        private readonly IExercisePerMesoRepo repo;

        public ExercisePerMesoController(IExercisePerMesoRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var ePM = repo.GetAll(); 
            return View(ePM);
        }
    }
}

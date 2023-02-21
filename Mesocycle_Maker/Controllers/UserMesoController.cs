using Microsoft.AspNetCore.Mvc;
using Mesocycle_Maker.Models;

namespace Mesocycle_Maker.Controllers
{
    public class UserMesoController : Controller
    {
        private readonly IUserMesoRepo repo;

        public UserMesoController(IUserMesoRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult NewUserMeso(User user)
        {
            repo.InsertUserMeso(user.UserMesoGoal, user.UserMesoWeekLength);
            var newUser = repo.GetOneWithoutID(user.UserMesoGoal, user.UserMesoWeekLength);
            return View("NewUserMeso", newUser);
        }
    }
}

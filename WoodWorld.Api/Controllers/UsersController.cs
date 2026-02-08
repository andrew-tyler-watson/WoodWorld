using Microsoft.AspNetCore.Mvc;

namespace WoodWorld.Api.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

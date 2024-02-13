using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ISeedUserRoleInitial _userRoleInitial;
        public HomeController(ISeedUserRoleInitial userRoleInitial)
        {
            _userRoleInitial = userRoleInitial;
        }

        public IActionResult Index()
        {
            _userRoleInitial.SeedRoles();
            _userRoleInitial.SeedUsers();

            return View();
        }
    }
}

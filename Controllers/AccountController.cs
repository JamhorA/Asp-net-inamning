using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers
{
    public class AccountController : Controller
    {
        
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Register(RegisterViewModel registerViewModel)
		{
			return View(registerViewModel);
		}

		public IActionResult Login()
		{
			return View();
		}








		public IActionResult Index()
        {
            return View();
        }
    }
}

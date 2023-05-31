using Bmerketo_WebApp.Helpers.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers;

public class LoginController : Controller
{
	private readonly AuthenticationService _authenticationService;

	public LoginController(AuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
	}

	public IActionResult Index()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Index(LoginViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			if (await _authenticationService.LoginAsync(viewModel))
			{
				return RedirectToAction("Index", "Account");
			}
			ModelState.AddModelError("", "Invalid email or password. Please try again.");
		}
		return View(viewModel);
	}

    [Authorize]
    public async Task<IActionResult> Logout()
    {
		if (await _authenticationService.SignOutAsync(User))
			return LocalRedirect("/");
		return RedirectToAction("Index");
    }
}

using Bmerketo_WebApp.Helpers.Services;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Controllers;

public class RegisterController : Controller
{
	private readonly UserManager<UserEntity> _userManager;
	private readonly AuthenticationService _authenticationService;

	public RegisterController(UserManager<UserEntity> userManager, AuthenticationService authenticationService)
	{
		_userManager = userManager;
		_authenticationService = authenticationService;
	}

	public IActionResult Index()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Index(UserRegisterViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
			{
				if (await _authenticationService.SignUpAsync(viewModel))
					return RedirectToAction("Index", "Login");
			}
			ModelState.AddModelError("", "A user with the provided email already exists.");
		}
		return View(viewModel);
	}
}

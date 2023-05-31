using Bmerketo_WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bmerketo_WebApp.Controllers;

public class AccountController : Controller
{
	private readonly UserService _userService;

	public AccountController(UserService userService)
	{
		_userService = userService;
	}
	

	public IActionResult Register()
    {
        return View();
    }

	[Authorize]
	public IActionResult Index()
	{
		return View();
	}

	
}

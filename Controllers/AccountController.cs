using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Bmerketo_WebApp.Controllers
{
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
        [HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid)
			{
				if(await _userService.UserExists(u => u.Email == registerViewModel.Email))
						ModelState.AddModelError("", "A user with the provided email already exists.");
				else
				{
					if(await _userService.RegisterUserAsync(registerViewModel))
					   return RedirectToAction("Index", "Home");
					else
						ModelState.AddModelError("", "An error occurred during registration. Please try again.");
				}
									
			}
			
			return View(registerViewModel);
		}


		//public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		//{
		//          if (ModelState.IsValid)
		//          {
		//              try
		//              {
		//			// convert userEntity and profileEntity from registrationform
		//			UserEntity userEntity = registerViewModel;
		//			ProfileEntity profileEntity = registerViewModel;

		//			// create user
		//			_context.Users.Add(userEntity);
		//			await _context.SaveChangesAsync();

		//			// create user profile
		//			profileEntity.UserId = userEntity.Id;
		//			_context.Profiles.Add(profileEntity);
		//			await _context.SaveChangesAsync();

		//			return RedirectToAction("Index", "Home");
		//		}
		//		catch
		//		{
		//			ModelState.AddModelError("", "An error occurred during registration. Please try again.");
		//		}

		//          }
		//	return View(registerViewModel);
		//}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				if(await _userService.LoginAsync(loginViewModel))
					return RedirectToAction("Index", "Account");

				ModelState.AddModelError("", "Invalid email or password. Please try again.");
			}
			
			return View(loginViewModel);
		}








		public IActionResult Index()
        {
            return View();
        }
    }
}

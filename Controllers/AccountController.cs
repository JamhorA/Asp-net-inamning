using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;

		public AccountController(DataContext context)
		{
			_context = context;
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
				try
				{
					// Check if user already exists
					bool userExists = await _context.Users.AnyAsync(u => u.Email == registerViewModel.Email);

					if (userExists)
					{
						ModelState.AddModelError("", "A user with the provided email already exists.");
					}
					else
					{
						// Convert userEntity and profileEntity from registration form
						UserEntity userEntity = registerViewModel;
						ProfileEntity profileEntity = registerViewModel;

						// Create user
						_context.Users.Add(userEntity);
						await _context.SaveChangesAsync();

						// Create user profile
						profileEntity.UserId = userEntity.Id;
						_context.Profiles.Add(profileEntity);
						await _context.SaveChangesAsync();

						return RedirectToAction("Index", "Home");
					}
				}
				catch
				{
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
				var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginViewModel.Email);
				if (userEntity != null)
				{
					if(userEntity.VerifySecurePassword(loginViewModel.Password))
						return RedirectToAction("Index", "Account");
				}
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

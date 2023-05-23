using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bmerketo_WebApp.Services;

public class UserService
{
	private readonly DataContext _context;

	public UserService(DataContext context)
	{
		_context = context;
	}

	public async Task<bool> UserExists(Expression<Func<UserEntity, bool>> predicate)
	{
		if (await _context.Users.AnyAsync(predicate))
			return true;
		return false;
	}
	public async Task<UserEntity> GetUserAsync(Expression<Func<UserEntity, bool>> predicate)
	{
		var userEntity = await _context.Users.FirstOrDefaultAsync(predicate);
		return userEntity!;
	}
	public async Task<bool> RegisterUserAsync(RegisterViewModel registerViewModel)
	{
		
			try
			{
					//ModelState.AddModelError("", "A user with the provided email already exists.");

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

			        return true;

					//return RedirectToAction("Index", "Home");
				
			}
			catch
			{
			return false;
				//ModelState.AddModelError("", "An error occurred during registration. Please try again.");
			}
		
	}

	public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
	{
		var userEntity = await GetUserAsync(u => u.Email == loginViewModel.Email);
		if(userEntity != null)
			return userEntity.VerifySecurePassword(loginViewModel.Password);
		return false;
	}
}

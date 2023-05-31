using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.Services;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Bmerketo_WebApp.Helpers.Services;

public class AuthenticationService
{
	private readonly IdentityContext _identityContext;
	private readonly UserManager<UserEntity> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly SignInManager<UserEntity> _signInManager;
	private readonly AddressService _addressService;
	private readonly SeedService _seedService;



    public AuthenticationService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService, IdentityContext identityContext, RoleManager<IdentityRole> roleManager, SeedService seedService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _addressService = addressService;
        _identityContext = identityContext;
        _roleManager = roleManager;
        _seedService = seedService;
    }
    public async Task<bool> SignUpAsync(UserRegisterViewModel model)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            UserEntity userEntity = model;

            var addressEntity = new AddressEntity
            {
                StreetName = model.StreetName,
                City = model.City,
                PostalCode = model.PostalCode
            };

            userEntity.UserProfiles.Add(new UserProfileEntity
            {
                User = userEntity,
                Address = addressEntity
            });

            // Kontrollera om det redan finns en instans av UserProfileEntity i databaskontexten
            var existingProfile = await _identityContext.UserProfiles.FindAsync(userEntity.Id, addressEntity.Id);
            if (existingProfile != null)
            {
                // Uppdatera befintlig instans med de nya värdena
                _identityContext.Entry(existingProfile).CurrentValues.SetValues(userEntity.UserProfiles.First());
            }
            else
            {
                // Lägg till ny UserProfileEntity
                _identityContext.UserProfiles.Add(userEntity.UserProfiles.First());
            }
            await _userManager.CreateAsync(userEntity, model.Password);
            await _userManager.AddToRoleAsync(userEntity, roleName);
            await _identityContext.SaveChangesAsync();

            

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> LoginAsync(LoginViewModel viewModel)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            return result.Succeeded;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    public async Task<bool> SignOutAsync(ClaimsPrincipal user)
	{
		try
		{
			await _signInManager.SignOutAsync();
			if (!_signInManager.IsSignedIn(user))
				return true;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return false;
		
	}

}

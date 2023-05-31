using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Helpers.Services;

public class UserAdminService
{
	private readonly UserManager<UserEntity> _userManager;

	public UserAdminService(UserManager<UserEntity> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IEnumerable<User>> GetUsersAsync()
	{
		var users = new List<User>();
		foreach (var user in await _userManager.Users.ToListAsync())
		{
			var _user = new User
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email
			};
			foreach (var role in await _userManager.GetRolesAsync(user))
			{
				_user.RoleNames.Add(role);
			}
			users.Add(_user);
		}
		return users;

	}
    public async Task<bool> ChangeUserRoleAsync(string userId, string newRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return false;
        }

        var currentRoles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);

        if (result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(user, newRole);
            return result.Succeeded;
        }

        return false;
    }
}
public class User
{
	public string? Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public List<string> RoleNames { get; set; } = new List<string>();
    public string? NewRole { get; set; }

}

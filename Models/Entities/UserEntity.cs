using Microsoft.AspNetCore.Identity;


namespace Bmerketo_WebApp.Models.Entities;

public class UserEntity : IdentityUser
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? MobileNumber { get; set; }

	public ICollection<UserProfileEntity> UserProfiles { get; set; } = new HashSet<UserProfileEntity>();
}

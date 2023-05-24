using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace Bmerketo_WebApp.Models.Entities;

//public class UserEntity : IdentityUser
//{
//public new Guid Id { get; set; } = Guid.NewGuid();
//public new string Email { get; set; } = null!;

//public string Password { get; set; } = null!;

//public byte[] Password { get;private set; } = null!;
//public byte[] SecurityKey { get; private set; } = null!;
//public string? MobileNummber { get; set; }

//public void GenerateSecurePassword(string password)
//{
//	using var hmac = new HMACSHA512();
//	SecurityKey = hmac.Key;
//	Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
//}
//public bool VerifySecurePassword(string password)
//{
//	using var hmac = new HMACSHA512(SecurityKey);
//	var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

//	for (int i = 0; i < hash.Length; i++)
//	{
//		if (hash[i] != Password[i])
//			return false;
//	}
//	return true;
//}
//	public ICollection<UserProfileEntity> UserProfiles { get; set; } = new HashSet<UserProfileEntity>();
//}
public class UserEntity : IdentityUser
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? MobileNumber { get; set; }

	public ICollection<UserProfileEntity> UserProfiles { get; set; } = new HashSet<UserProfileEntity>();
}

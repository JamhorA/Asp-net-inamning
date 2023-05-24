using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Models.Entities;

[PrimaryKey("UserId", "AddressId")]
public class UserProfileEntity
{
	public string UserId { get; set; } = null!;
	public UserEntity User { get; set; } = null!;
	public int AddressId { get; set; }
	public AddressEntity Address { get; set; } = null!;

}

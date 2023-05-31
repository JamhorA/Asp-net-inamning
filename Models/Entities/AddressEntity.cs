using Microsoft.AspNetCore.Identity;

namespace Bmerketo_WebApp.Models.Entities;

public class AddressEntity
{
	public int Id { get; set; }
	public string StreetName { get; set; } = null!;
	public string City { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public ICollection<UserProfileEntity> UserProfiles { get; set; } = new HashSet<UserProfileEntity>();

}
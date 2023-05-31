using Bmerketo_WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class UserRegisterViewModel
{
	public string Id { get; set; } = Guid.NewGuid().ToString();
	//public string Id { get; set; } = null!;
	[Display(Name = "First Name*")]
	public string FirstName { get; set; } = null!;
	[Display(Name = "Last Name*")]
	public string LastName { get; set; } = null!;
    [Display(Name = "Email*")]
    [Required(ErrorMessage = "E-mail is required.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Password must contain at least 8 characters, including one uppercase letter, one lowercase letter, one digit, and one special character.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [Display(Name = "Password*")]
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Display(Name = "Confirm Password*")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;
    [Display(Name = "Mobile Number")]
	public string? MobileNumber { get; set; }
	[Display(Name = "Company")]
	public string? Company { get; set; }
	[Display(Name = "Street Name*")]
	public string StreetName { get; set; } = null!;
	[Display(Name = "City*")]
	public string City { get; set; } = null!;
	[Display(Name = "Postal Code*")]
	public string PostalCode { get; set; } = null!;


	// Övriga egenskaper i UserRegisterViewModel


	public static implicit operator UserEntity(UserRegisterViewModel viewModel)
	{
		var userEntity = new UserEntity
		{
			UserName = viewModel.Email,
			FirstName = viewModel.FirstName,
			LastName = viewModel.LastName,
			Email = viewModel.Email,
			MobileNumber = viewModel.MobileNumber,
			Id = viewModel.Id,
		};
        var addressEntity = new AddressEntity
        {
            StreetName = viewModel.StreetName,
            City = viewModel.City,
            PostalCode = viewModel.PostalCode
        };

        userEntity.UserProfiles.Add(new UserProfileEntity
        {
            User = userEntity,
            Address = addressEntity
        });

        //userEntity.UserProfiles.Add(new UserProfileEntity
        //{
        //	User = userEntity,

        //	//Address = new AddressEntity
        //	//{
        //	//	StreetName = viewModel.StreetName,
        //	//	City = viewModel.City,
        //	//	PostalCode = viewModel.PostalCode,
        //	//}

        //});
        //var addressEntity = new AddressEntity
        //{
        //	StreetName = viewModel.StreetName,
        //	City = viewModel.City,
        //	PostalCode = viewModel.PostalCode,
        //};

        return userEntity;
	}
	public static implicit operator AddressEntity(UserRegisterViewModel viewModel)
	{
		var addressEntity = new AddressEntity
		{
			StreetName = viewModel.StreetName,
			City = viewModel.City,
			PostalCode = viewModel.PostalCode,
		};
		return addressEntity;
	}


}



using Bmerketo_WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class RegisterViewModel
{
	[Required(ErrorMessage = "First name is required")]
	[RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+(?:[ é'-][a-zA-ZåäöÅÄÖ]+)*$", ErrorMessage = "First name must consist of letters, hyphens, spaces, and special characters like é and ' (apostrophe).")]
	[Display(Name = "First Name*")]
	
	public string FirstName { get; set; } = null!;



	[Required(ErrorMessage = "Last name is required")]
	[RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+(?:[ é'-][a-zA-ZåäöÅÄÖ]+)*$", ErrorMessage = "Last name must consist of letters, hyphens, spaces, and special characters like é and ' (apostrophe).")]
	[Display(Name = "Last Name*")]
	public string LastName { get; set; } = null!;

	[Required(ErrorMessage = "Email is required")]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
	[DataType(DataType.EmailAddress)]
	[Display(Name = "E-mail*")]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "Password is required")]
	[RegularExpression(@"^(?=.*[A-Z])(?=.*[\d])(?=.*[^a-zA-Z\d]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit")]
	[DataType(DataType.Password)]
	[Display(Name = "Password*")]
	public string Password { get; set; } = null!;


	[Required(ErrorMessage = "Please confirm your password")]
	[DataType(DataType.Password)]
	[Display(Name = "Confirm Password*")]
	[Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
	public string ConfirmPassword { get; set; } = null!;


	[Required(ErrorMessage = "Street name is required")]
	[Display(Name = "Street Name*")]
	public string StreetName { get; set; } = null!;

	[Required(ErrorMessage = "Postal code is required")]
	[Display(Name = "Postal Code*")]
	public string PostalCode { get; set; } = null!;

	[Required(ErrorMessage = "City is required")]
	[Display(Name = "City*")]
	public string City { get; set; } = null!;




	[Display(Name = "Mobile (optional)")]
	public string? MobileNummber { get; set; }



	[Display(Name = "Company (optional)")]
	public string? Company { get; set; }

	//public static implicit operator UserEntity(RegisterViewModel registerViewModel)
	//{
	//	var userEntity = new UserEntity { Email = registerViewModel.Email };
	//	userEntity.GenerateSecurePassword(registerViewModel.Password);
	//	return userEntity;
	//}
	//public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
	//{
	//	return new ProfileEntity
	//	{
	//		FirstName = registerViewModel.FirstName,
	//		LastName = registerViewModel.LastName,
	//		StreetName = registerViewModel.StreetName,
	//		PostalCode = registerViewModel.PostalCode,
	//		City = registerViewModel.City,
	//		MobileNummber = registerViewModel.MobileNummber,
	//		Company = registerViewModel.Company
	//	};
	//}

}

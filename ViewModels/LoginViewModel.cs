using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class LoginViewModel
{
	[Required(ErrorMessage = "Email is required")]
	//[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
	[DataType(DataType.EmailAddress)]
	[Display(Name = "E-mail*")]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "Password is required")]
	//[RegularExpression(@"^(?=.*[A-Z])(?=.*[\d])(?=.*[^a-zA-Z\d]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit")]
	[DataType(DataType.Password)]
	[Display(Name = "Password*")]
	public string Password { get; set; } = null!;
}

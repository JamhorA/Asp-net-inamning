using Bmerketo_WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class LoginViewModel
{
	[Display(Name = "Email*")]
	[Required(ErrorMessage = "E-mail is required.")]
	[DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Password or Email.")]
    public string Email { get; set; } = null!;

	[Display(Name = "Password*")]
	[Required(ErrorMessage = "Password is required.")]
	[DataType(DataType.Password)]
    
    public string Password { get; set; } = null!;
	public bool RememberMe { get; set; } = false;


}

using Bmerketo_WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo_WebApp.ViewModels;

public class ContactFormViewModel
{
	[Required]
	public string Name { get; set; } = null!;
	[Required]
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string? Company { get; set; }
	[Required]
	public string Message { get; set; } = null!;

	public static implicit operator ContactFormEntity(ContactFormViewModel model)
	{
		var contactFormEntity = new ContactFormEntity
		{
			Name = model.Name,
			Email = model.Email,
			PhoneNumber = model.PhoneNumber,
			Company = model.Company,
			Message = model.Message
		};
		return contactFormEntity;
	}

}

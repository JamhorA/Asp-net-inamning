﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

public class ProfileEntity
{
	[Key, ForeignKey("User")]
	public Guid UserId { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;

	
	public string? Company { get; set; }


	public string StreetName { get; set; } = null!;
	public string City { get; set; } = null!;
	public string PostalCode { get; set; } = null!;

	
	public UserEntity User { get; set; } = null!;

}
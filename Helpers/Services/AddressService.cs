using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Helpers.Repositories;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;

namespace Bmerketo_WebApp.Helpers.Services;

public class AddressService
{
	private readonly AddressRepository _addressRepository;
	private readonly UserProfileRepository _userProfileRepository;
    private readonly DbContextOptions<IdentityContext> options;

    public AddressService(AddressRepository addressRepository, UserProfileRepository userProfileRepository, DbContextOptions<IdentityContext> options)
    {
        _addressRepository = addressRepository;
        _userProfileRepository = userProfileRepository;
        this.options = options;
    }

 
    public async Task<bool> AddUserAddress(string userId, int adressId)
	{
		try
		{
			var entity = await _userProfileRepository.AddAddressAsync(
					new UserProfileEntity 
					{ 
						UserId = userId, 
						AddressId = adressId 
					});
			if (entity != null) 
				return true;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message);}
		return false;
	}
}

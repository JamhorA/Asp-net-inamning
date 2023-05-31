using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Bmerketo_WebApp.Factories;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserEntity>
{
    private readonly UserService _userService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<UserEntity> _userManager;
    public CustomClaimsPrincipalFactory(UserManager<UserEntity> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService, RoleManager<IdentityRole> roleManager) : base(userManager, optionsAccessor)
    {
        _userService = userService;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);
        var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);
        // Lägg till rollen som en claim
        var roles = await _userManager.GetRolesAsync(user);
        if (roles != null && roles.Any())
        {
            // Lägg till rollen som en claim
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, roles.First()));
        }
        claimsIdentity.AddClaim(new Claim("DisplayName", $" {user.FirstName}"));
        return claimsIdentity;
    }
}


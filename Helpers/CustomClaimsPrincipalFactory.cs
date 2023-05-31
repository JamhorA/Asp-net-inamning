using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Bmerketo_WebApp.Helpers;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserEntity, IdentityRole>
{
    public CustomClaimsPrincipalFactory(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
    {
        var identity = await base.GenerateClaimsAsync(user);

        // Här kan du lägga till ytterligare anpassning av ClaimsPrincipal, om det behövs
        // Du kan lägga till eller ta bort claims baserat på dina behov

        return identity;
    }
}


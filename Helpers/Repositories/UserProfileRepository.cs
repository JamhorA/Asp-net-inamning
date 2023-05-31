using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class UserProfileRepository : Repo<UserProfileEntity>
{
	public UserProfileRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
	}
}

using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class ContactFormRepository : Repo<ContactFormEntity>
{
	public ContactFormRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
	}
}

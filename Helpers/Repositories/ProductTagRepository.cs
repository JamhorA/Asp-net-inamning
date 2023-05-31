using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class ProductTagRepository : Repo<ProductTagEntity>
{
	public ProductTagRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
	}
}

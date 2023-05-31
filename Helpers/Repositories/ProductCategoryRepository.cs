using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class ProductCategoryRepository : Repo<ProductCategoryEntity>
{
	public ProductCategoryRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
	}
}

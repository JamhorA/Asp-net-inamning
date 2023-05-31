using Bmerketo_WebApp.Contexts;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class ProductRelationshipRepository : Repo<ProductRelationshipRepository>
{
	public ProductRelationshipRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
	}
}

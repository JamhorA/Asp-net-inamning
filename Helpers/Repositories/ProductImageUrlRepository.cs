using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class ProductImageUrlRepository : Repo<ProductImageUrlRepository>
{
    private readonly DataContext _dataContext;
	public ProductImageUrlRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
        _dataContext = dataContext;
	}


}

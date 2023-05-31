using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Dtos;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class ProductRepository : Repo<ProductEntity>
{
	private readonly DataContext _dataContext;

	

	public ProductRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
	{
		_dataContext = dataContext;
	}


    public override async Task<IEnumerable<ProductEntity>> FindImageAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _dataContext.Products
                .Include(x => x.ProductRelationshipEntities)
                .ThenInclude(x => x.ImageUrl)
            .ToListAsync();
    }

    public override async Task<IEnumerable<ProductEntity>> GetAsync()
    {
        var products = await _dataContext.Products
            .Include(x => x.ProductRelationshipEntities)
                .ThenInclude(x => x.Category)
                .Include(x => x.ProductRelationshipEntities)
                .ThenInclude(x => x.ImageUrl)
            .ToListAsync();

        return products;
    }


    public override async Task<ProductEntity?> GetByIdAsync(int id)
    {
        var product = await _dataContext.Products.Include(x => x.ProductRelationshipEntities).ThenInclude(x => x.Category).FirstOrDefaultAsync();
		return product!;
    }
}

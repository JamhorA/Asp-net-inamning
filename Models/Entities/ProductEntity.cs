using Bmerketo_WebApp.Models.Dtos;
using Bmerketo_WebApp.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

public class ProductEntity
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string? Description { get; set; }

	[Column(TypeName = "money")]
	public decimal? Price { get; set;} = null!;

	public ICollection<ProductRelationshipEntity> ProductRelationshipEntities { get; set; } = new HashSet<ProductRelationshipEntity>();

    public static implicit operator Product(ProductEntity entity)
	{
		return new Product
		{
			Id = entity.Id,
			Title = entity.Title,
			Description = entity.Description,
			Price = entity.Price,
			ProductRelationshipEntities = entity.ProductRelationshipEntities,
        };
	}

}

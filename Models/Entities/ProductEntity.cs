using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

public class ProductEntity
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string? Description { get; set; }

	[Column(TypeName = "money")]
	public decimal? Price { get; set;} = null!;

	//public ICollection<ProductImageUrlEntity> ProductImagesUrl { get; set; } = new HashSet<ProductImageUrlEntity>();
	public ICollection<ProductRelationshipEntity> ProductRelationshipEntities { get; set; } = new HashSet<ProductRelationshipEntity>();
}

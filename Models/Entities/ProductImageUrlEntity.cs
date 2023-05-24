using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

//[PrimaryKey("ProductId")]
public class ProductImageUrlEntity
{
	public int Id { get; set; }
	public string? ImageUrlName { get; set; }

	//[ForeignKey(nameof(ProductId))]
	//public int ProductId { get; set; }
	//public ProductEntity? Product { get; set; }
	public ICollection<ProductRelationshipEntity> ProductRelationshipEntities { get; set; } = new HashSet<ProductRelationshipEntity>();

}

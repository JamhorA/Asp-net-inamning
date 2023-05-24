using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

//[PrimaryKey("Id","ProductId", "CategoryId", "TagId", "ImageUrlId")]
[PrimaryKey("Id")]
public class ProductRelationshipEntity
{
	
	public int Id { get; set; }

	[ForeignKey(nameof(ProductId))]
	public int ProductId { get; set; }
	public ProductEntity Product { get; set; } = null!;
	[ForeignKey(nameof(CategoryId))]
	public int CategoryId { get; set; }
	public ProductCategoryEntity Category { get; set; } = null!;
	[ForeignKey(nameof(TagId))]
	public int TagId { get; set; }
	public ProductTagEntity Tag { get; set; } = null!;
	[ForeignKey(nameof(ImageUrlId))]
	public int ImageUrlId { get; set; }
	public ProductImageUrlEntity ImageUrl { get; set; } = null!;
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Entities;

[PrimaryKey("ProductId", "CategoryId", "TagId", "ImageUrlId")]
public class ProductRelationshipEntity
{
	
	
	public int ProductId { get; set; }
	public ProductEntity Product { get; set; } = null!;
	public int CategoryId { get; set; }
	public ProductCategoryEntity Category { get; set; } = null!;
	public int TagId { get; set; }
	public ProductTagEntity Tag { get; set; } = null!;
	public int ImageUrlId { get; set; }
	public ProductImageUrlEntity ImageUrl { get; set; } = null!;
}

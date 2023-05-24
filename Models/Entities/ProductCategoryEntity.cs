namespace Bmerketo_WebApp.Models.Entities;

public class ProductCategoryEntity
{
	public int Id { get; set; }
	public string CategoryName { get; set; } = null!;
	public ICollection<ProductRelationshipEntity> ProductRelationshipEntities { get; set; } = new HashSet<ProductRelationshipEntity>();
}

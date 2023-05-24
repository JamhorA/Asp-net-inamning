namespace Bmerketo_WebApp.Models.Entities;

public class ProductTagEntity
{
	public int Id { get; set; }
	public string TagName { get; set; } = null!;
	public ICollection<ProductRelationshipEntity> ProductRelationshipEntities { get; set; } = new HashSet<ProductRelationshipEntity>();
}

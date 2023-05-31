using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.ViewModels;

public class ProductViewModel
{
	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	public decimal? Price { get; set; } = decimal.Zero!;
	public List<IFormFile> Images { get; set; } = new List<IFormFile>();

	public IEnumerable<GridCollectionItemViewModel> Items { get; set; } = new List<GridCollectionItemViewModel>();

	public static implicit operator ProductEntity(ProductViewModel model)
	{
		var entity = new ProductEntity
		{
			Title = model.Title,
			Description = model.Description,
			Price = model.Price,

		};
		var Images = new ProductImageUrlEntity
		{
			ImageUrlName = model.Images.ToString(),
		};
		if(model.Images != null)
		{
			foreach (var image in model.Images)
				Images.ImageUrlName = $"{Guid.NewGuid()}_{image.FileName}";
		}
		entity.ProductRelationshipEntities.Add(new ProductRelationshipEntity
		{
			Product = entity,
			ImageUrl = Images,
			CategoryId = 1,
			TagId = 2,
		});
		return entity;
		
	}

}


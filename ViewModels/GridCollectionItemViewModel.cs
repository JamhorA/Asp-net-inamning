using Bmerketo_WebApp.Models.Dtos;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.ViewModels;

public class GridCollectionItemViewModel
{
	public string Id { get; set; } = null!;
	public string Title { get; set; } = null!;
	public string? ImageUrl { get; set; }
    [Column(TypeName = "money")]
    public decimal? Price { get; set; } = null!;
	public string? Description { get; set; }

	public IEnumerable<Product> products { get; set; } = new List<Product>();
	
}

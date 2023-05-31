using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo_WebApp.Models.Dtos;

public class Product
{

    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; } = null!;
    public ICollection<ProductImageUrlEntity> Images { get; set; } = new List<ProductImageUrlEntity>();

    public ICollection<ProductRelationshipEntity> ProductRelationshipEntities { get; set; } = new HashSet<ProductRelationshipEntity>();
}

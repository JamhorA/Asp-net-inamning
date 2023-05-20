namespace Bmerketo_WebApp.Models;

public class UpToSellItemsModel
{
    public string Id { get; set; } = null!;
    public string? Title { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool? IsOnSale { get; set; }
}

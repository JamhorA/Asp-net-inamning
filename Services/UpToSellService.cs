
using Bmerketo_WebApp.Models;

namespace Bmerketo_WebApp.Services;

public class UpToSellService
{
    private readonly List<UpToSellItemsModel> _uptopsell = new()
    {
        new UpToSellItemsModel()
        {
            Id ="1",
            Title = "Now with all new spices",
            ImageUrl = "images/placeholders/369x310.svg",
            Price = 30,
            IsOnSale = true, // Lägg till detta attribut för att ange om produkten är på rea
        },
        new UpToSellItemsModel()
        {
            Id ="2",
            Title = "Exclusive Chair gold Collection.",
            ImageUrl = "images/placeholders/369x310.svg",
            Price = 30,
            IsOnSale = false,
        },
        new UpToSellItemsModel()
        {
            Id ="3",
            Title = "test",
            ImageUrl = "images/placeholders/369x310.svg",
            Price = 30,
            IsOnSale = true, // Lägg till detta attribut för att ange om produkten är på rea
        }

    };


    public List<UpToSellItemsModel> GetLatestOnSale()
    {
        return _uptopsell.Where(uptopsell => uptopsell.IsOnSale == true)
                         .TakeLast(2)
                         .ToList();
    }

}

namespace Bmerketo_WebApp.ViewModels;
public class TopSellingViewModels
{
    public string Title { get; set; } = "";
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;

}

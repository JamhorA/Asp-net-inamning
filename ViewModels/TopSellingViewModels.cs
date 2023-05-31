namespace Bmerketo_WebApp.ViewModels;

public class TopSellingViewModels
{
	public string Title { get; set; } = null!;
	public List<GridCollectionItemViewModel> GridItems { get; set; } = new List<GridCollectionItemViewModel>();
}

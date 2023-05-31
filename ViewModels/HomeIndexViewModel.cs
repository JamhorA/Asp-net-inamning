namespace Bmerketo_WebApp.ViewModels;

public class HomeIndexViewModel
{
	public GridCollectionViewModel BestCollection { get; set; } = new GridCollectionViewModel();
	public TopSellingViewModels TopSellingThisWeek { get; set; } = new TopSellingViewModels();
}

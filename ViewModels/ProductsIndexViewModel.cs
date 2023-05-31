namespace Bmerketo_WebApp.ViewModels;

public class ProductsIndexViewModel
{
	public string Title { get; set; } = "Psoducts";
	public GridCollectionViewModel All { get; set; } = new GridCollectionViewModel();

}

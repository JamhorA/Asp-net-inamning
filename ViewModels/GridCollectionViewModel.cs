namespace Bmerketo_WebApp.ViewModels;

public class GridCollectionViewModel
{
	public string Title { get; set; } = null!;
	public string Category { get; set; } = null!;
	public bool LoadMore { get; set; } = false;

	public List<string> Categories { get; set; } = new List<string>();
	public List<GridCollectionItemViewModel> GridItems { get; set; } = new List<GridCollectionItemViewModel>();

}

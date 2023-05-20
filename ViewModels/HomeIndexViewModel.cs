namespace Bmerketo_WebApp.ViewModels;

    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public GridCollectionViewModel SummerCollection { get; set; } = null!;
        public TopSellingViewModels TopSellingThisWeek { get; set;} = null!;
    }


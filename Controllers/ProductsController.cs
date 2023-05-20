﻿using Microsoft.AspNetCore.Mvc;
using Bmerketo_WebApp.ViewModels;

namespace Bmerketo_WebApp.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new ProductsIndexViewModel
        {
            All = new GridCollectionViewModel
            {
                Title = "All Products",
                Categories = new List<string> { "All", "Mobile", "Computers" }
            }
        };
        return View(viewModel);
    }
    public IActionResult Details()
    {
        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                Title = "Related Products",
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1" , Title = "Apple watch collection", Price = 10, ImageUrl = "../../images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "2" , Title = "Apple watch collection", Price = 20, ImageUrl = "../../images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "3" , Title = "Apple watch collection", Price = 30, ImageUrl = "../../images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "4" , Title = "Apple watch collection", Price = 40, ImageUrl = "../../images/placeholders/270x295.svg" }/*,*/
                    //new GridCollectionItemViewModel { Id = "5" , Title = "Apple watch collection", Price = 50, ImageUrl = "../../images/placeholders/270x295.svg" },
                    //new GridCollectionItemViewModel { Id = "6" , Title = "Apple watch collection", Price = 60, ImageUrl = "../../images/placeholders/270x295.svg" },
                    //new GridCollectionItemViewModel { Id = "7" , Title = "Apple watch collection", Price = 70, ImageUrl = "../../images/placeholders/270x295.svg" },
                    //new GridCollectionItemViewModel { Id = "8" , Title = "Apple watch collection", Price = 80, ImageUrl = "../../images/placeholders/270x295.svg" }
                },
                //LoadMore = true,


            },
            TopSellingThisWeek = new TopSellingViewModels
            {
                Title = "Top selling products in this week",
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1" , Title = "Apple watch collection", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "2" , Title = "Apple watch collection", Price = 20, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "3" , Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "4" , Title = "Apple watch collection", Price = 40, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "5" , Title = "Apple watch collection", Price = 50, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "6" , Title = "Apple watch collection", Price = 60, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "7" , Title = "Apple watch collection", Price = 70, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "8" , Title = "Apple watch collection", Price = 80, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "9" , Title = "Apple watch collection", Price = 80, ImageUrl = "images/placeholders/270x295.svg" }
                },
            }
        };
        return View(viewModel);
    }
}

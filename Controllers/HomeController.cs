using Microsoft.AspNetCore.Mvc;
using  Bmerketo_WebApp.ViewModels;
using Bmerketo_WebApp.Helpers.Services;

namespace Bmerketo_WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult IndexAsync()
    {

        return View();
    }
    public async Task<IActionResult> IndexTset()
    {
        var viewModel = new GridCollectionItemViewModel
        {
            products = await _productService.GetAllAsync()
        };


        return View(viewModel);
    }
}

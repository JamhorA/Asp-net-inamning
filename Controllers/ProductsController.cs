using Microsoft.AspNetCore.Mvc;
using Bmerketo_WebApp.ViewModels;

namespace Bmerketo_WebApp.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {

        return View();
    }
    public IActionResult Details(int id)
    {
        return View(id);
    }

}

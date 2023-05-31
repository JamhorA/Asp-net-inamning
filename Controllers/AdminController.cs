using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Helpers.Services;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;


namespace Bmerketo_WebApp.Controllers;
[Authorize(Roles = "admin")]
public class AdminController : Controller
{



	private readonly DataContext _dataContext;
	private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly UserAdminService _userAdminService;

    public AdminController(DataContext dataContext, IWebHostEnvironment webHostEnvironment, UserAdminService userAdminService)
    {
        _dataContext = dataContext;
        _webHostEnvironment = webHostEnvironment;
        _userAdminService = userAdminService;
    }
    [HttpPost]
	public async Task<IActionResult> AddProduct(ProductViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			List<string> imagePaths = new List<string>();
			for (int i = 0; i < viewModel.Images.Count; i++)
			{
				var image = viewModel.Images[i];

				if (image != null && image.Length > 0)
				{
                    var webHo = $"{_webHostEnvironment.WebRootPath}/images/products/";
                    var imagePath = $"{Guid.NewGuid()}_{image.FileName}";
                    var webHoImagePath = webHo + imagePath;
                    await image.CopyToAsync(new FileStream(webHoImagePath, FileMode.Create));
					imagePaths.Add(imagePath);
				}
			}
            var productEntity = new ProductEntity
			{
				Title = viewModel.Title,
				Description = viewModel.Description,
				Price = viewModel.Price,

			};


            foreach (var imagePath in imagePaths)
            {
                var imageEntity = new ProductImageUrlEntity
                {
                    ImageUrlName = imagePath,
                };
                productEntity.ProductRelationshipEntities.Add(new ProductRelationshipEntity { ImageUrl = imageEntity, CategoryId = 1, TagId = 2 });
            }


                _dataContext.Products.Add(productEntity);
			_dataContext.SaveChanges();

			return RedirectToAction("AddProduct", "Admin"); // Redirect till en annan vy efter att produkten har lagts till
		}

		return View(viewModel);
	}


	public IActionResult Index()
	{
		return View();
	}


    [HttpPost]
    public async Task<IActionResult> ChangeRole(string userId, string newRole)
    {
        var result = await _userAdminService.ChangeUserRoleAsync(userId, newRole);
        if (result)
        {
            return RedirectToAction("Index");
        }
        else
        {
            // Hantera fel vid rolländring
            return RedirectToAction("Error");
        }
    }
    public IActionResult ChangeRole()
    {
        return View();
    }

    public IActionResult AddProduct()
	{
		return View();
	}

    
}


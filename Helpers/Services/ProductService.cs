using Bmerketo_WebApp.Helpers.Repositories;
using Bmerketo_WebApp.Models.Dtos;
using Bmerketo_WebApp.Models.Entities;

namespace Bmerketo_WebApp.Helpers.Services;

public class ProductService
{
    private readonly ProductRepository _productRepo;

    public ProductService(ProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<bool> CreateProductAsync(ProductEntity entity)
    {
        var product = await _productRepo.GetAsync(x => x.Title == entity.Title);
        //var productIamge = await _productImageUrlRepository.GetAsync(x => x.);
        if (product == null)
        {
            product = await _productRepo.AddProductAsync(entity);
            if (product != null)
                return true;
        }
        return false;
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var items = await _productRepo.GetAllAsync();
        var list = new List<Product>();
        foreach (var item in items)
            list.Add(item);
        return list;
    }
}

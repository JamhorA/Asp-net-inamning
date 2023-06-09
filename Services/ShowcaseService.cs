﻿using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Helpers.Repositories;
using Bmerketo_WebApp.Models;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo_WebApp.Services;

public class ShowcaseService
{
    private readonly DataContext _dataContext;
    private readonly ProductRepository _productRepository;

    public ShowcaseService(ProductRepository productRepository, DataContext dataContext)
    {
        _productRepository = productRepository;
        _dataContext = dataContext;
    }
    public async Task<ProductEntity> GetLatestProductAsync()
    {
        var latestProduct = await _dataContext.Products.LastOrDefaultAsync();

        return latestProduct!;
    }
   


    private readonly List<ShowcaseModel> _showcases = new() 
    {
                new ShowcaseModel()
        {
            Ingress = "BMERKETO THE BEST A PERSON CAN GET",
            Title = "Now with all new spices",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        },
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection.",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        }

    };
    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }

}

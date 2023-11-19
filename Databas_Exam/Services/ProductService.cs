using Databas_Exam.Models;
using Databas_Exam.Entities;
using Databas_Exam.Repositories;
using System.Diagnostics;

namespace Databas_Exam.Services;

internal class ProductService
{

    private readonly ProductRepository _productRepository;
    private readonly PricingUnitRepository _pricingUnitRepository;
    private readonly ProductCategoryRepository _productCategoryRepository;
    public ProductService(ProductRepository productRepository, PricingUnitRepository pricingUnitRepository, ProductCategoryRepository productCategoryRepository)
    {
        _productRepository = productRepository;
        _pricingUnitRepository = pricingUnitRepository;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<bool> CreateProductAsync(ProductRegistrationForm form)
    {
        if (!await _productRepository.ExistsAsync(x => x.ProductName == form.ProductName))
        {
                var pricingUnitEntity = await _pricingUnitRepository.GetAsync(x => x.Unit == form.PricingUnit);
                pricingUnitEntity ??= await _pricingUnitRepository.CreateAsync(new PricingUnitEntity { Unit = form.PricingUnit });

                var productCategoryEntity = await _productCategoryRepository.GetAsync(x => x.CategoryName == form.ProductCategory);
                productCategoryEntity ??= await _productCategoryRepository.CreateAsync(new ProductCategoryEntity { CategoryName = form.ProductCategory });

            var productEntity = await _productRepository.CreateAsync(new ProductEntity
            {
                ProductName = form.ProductName,
                ProductDescription = form.ProductDescription,
                ProductPrice = form.ProductPrice,
                PricingUnitId = pricingUnitEntity.Id,
                ProductCategoryId = productCategoryEntity.Id 
            });


            if (productEntity != null)
                return true;
        }
        return false;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products;
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;
using Store_Website.Domain.Entities.Products;
using System;
using System.Linq;

namespace Store_Website.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDataBaseContext _context;

        public GetProductDetailForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForAdmindDto> Execute(long Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            return new ResultDto<ProductDetailForAdmindDto>()
            {
                Data = new ProductDetailForAdmindDto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Displayed,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList(),
                },
                IsSuccess = true,
                Message = "",
            };
        }

        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}

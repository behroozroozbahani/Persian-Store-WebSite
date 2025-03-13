using Microsoft.EntityFrameworkCore;
using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;
using Store_Website.Domain.Entities.Products;
using System;
using System.Linq;

namespace Store_Website.Application.Services.Products.Commands.RemoveCategory
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _context;

        public RemoveCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long CategoryId)
        {
            var categories = _context.Categories
                                     .Include(x => x.Products)
                                     .Where(x => x.Id == CategoryId ||
                                            x.ParentCategoryId == CategoryId)
                                     .ToList();

            var productsCategory = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.ProductFeatures)
                .Where(x => x.CategoryId == x.Category.Id &&
                       x.Category.ParentCategoryId == CategoryId)
                .Where(x => x.Id == x.ProductImages.FirstOrDefault().ProductId)
                .Where(x => x.Id == x.ProductFeatures.FirstOrDefault().ProductId)
                .ToList();

            if (categories == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }

            foreach (var item in categories)
            {
                item.RemoveTime = DateTime.Now;
                item.IsRemoved = true;

            }

            foreach (var products in productsCategory)
            {
                products.RemoveTime = DateTime.Now;
                products.IsRemoved = true;

                foreach (var images in products.ProductImages)
                {
                    images.RemoveTime = DateTime.Now;
                    images.IsRemoved = true;
                }

                foreach (var features in products.ProductFeatures)
                {
                    features.RemoveTime = DateTime.Now;
                    features.IsRemoved = true;
                }
            }

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت حذف شد"
            };
        }
    }
}
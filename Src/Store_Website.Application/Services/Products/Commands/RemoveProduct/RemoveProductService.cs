using Microsoft.EntityFrameworkCore;
using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;
using System;
using System.Linq;

namespace Store_Website.Application.Services.Products.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDataBaseContext _context;

        public RemoveProductService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long ProductId)
        {
            var product = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.ProductFeatures)
                .Where(x => x.Id == ProductId)
                .Where(x => x.Id == x.ProductImages.FirstOrDefault().ProductId)
                .Where(x => x.Id == x.ProductFeatures.FirstOrDefault().ProductId)
                .ToList();

            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }

            foreach (var item in product)
            {
                item.RemoveTime = DateTime.Now;
                item.IsRemoved = true;

                foreach (var images in item.ProductImages)
                {
                    images.RemoveTime = DateTime.Now;
                    images.IsRemoved = true;
                }
                
                foreach (var features in item.ProductFeatures)
                {
                    features.RemoveTime = DateTime.Now;
                    features.IsRemoved = true;
                }
            }

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد"
            };
        }
    }
}

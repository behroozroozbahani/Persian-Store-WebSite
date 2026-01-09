using Microsoft.EntityFrameworkCore;
using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common;
using Store_Website.Common.Dto;
using System.Linq;

namespace Store_Website.Application.Services.Products.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(x => x.Category)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(x => new ProductsFormAdminList_Dto
                {
                    ProductId = x.Id,
                    Brand = x.Brand,
                    CategoryName = x.Category.Name,
                    Description = x.Description,
                    Displayed = x.Displayed,
                    Inventory = x.Inventory,
                    Name = x.Name,
                    Price = x.Price,
                }).ToList();

            var categories = _context.Categories.ToList();

            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    Products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount,
                    Categories = categories
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
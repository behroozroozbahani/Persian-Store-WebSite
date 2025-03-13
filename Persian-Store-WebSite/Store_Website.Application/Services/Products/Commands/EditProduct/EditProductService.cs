using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;

namespace Store_Website.Application.Services.Products.Commands.EditProduct
{
    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext _context;

        public EditProductService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditProductDto request)
        {
            var product = _context.Products.Find(request.ProductId);

            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }

            product.Name = request.Name;
            product.Brand = request.Brand;
            product.CategoryId = request.CategoryId;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Inventory = request.Inventory;
            product.Displayed = request.Displayed;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش محصول انجام شد"
            };
        }
    }
}
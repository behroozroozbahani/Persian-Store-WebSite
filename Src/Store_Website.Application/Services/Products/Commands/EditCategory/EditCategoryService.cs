using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;

namespace Store_Website.Application.Services.Products.Commands.EditCategory
{
    public class EditCategoryService : IEditCategoryService
    {
        private readonly IDataBaseContext _context;

        public EditCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditCategoryDto request)
        {
            var category = _context.Categories.Find(request.CategoryId);

            if (category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }

            category.Name = request.Name;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش دسته بندی انجام شد"
            };
        }
    }
}

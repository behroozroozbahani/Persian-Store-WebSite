using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Common.Queries.GetCategory
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoryDto>> Execute();
    }

    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoryDto>> Execute()
        {
            try
            {
                var category = _context.Categories.Where(p => p.ParentCategoryId == null)
                    .ToList()
                    .Select(p => new CategoryDto
                    {
                        CatId = p.Id,
                        CategoryName = p.Name,
                    }).ToList();

                return new ResultDto<List<CategoryDto>>()
                {
                    Data = category,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

    public class CategoryDto
    {
        public long CatId { get; set; }
        public string CategoryName { get; set; }
    }
}

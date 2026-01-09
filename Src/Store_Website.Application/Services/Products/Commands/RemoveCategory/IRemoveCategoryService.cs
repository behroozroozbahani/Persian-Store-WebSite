using Store_Website.Common.Dto;

namespace Store_Website.Application.Services.Products.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(long CategoryId);
    }
}

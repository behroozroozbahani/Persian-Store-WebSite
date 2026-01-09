using Store_Website.Common.Dto;
using Store_Website.Domain.Entities.Products;

namespace Store_Website.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(long ProductId);
    }
}

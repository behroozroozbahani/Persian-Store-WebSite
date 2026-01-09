using Store_Website.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        ResultDto<ProductDetailForAdmindDto> Execute(long Id);

    }
}

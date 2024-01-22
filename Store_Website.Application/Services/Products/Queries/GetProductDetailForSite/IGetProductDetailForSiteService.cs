using Store_Website.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<ProductDetailForSiteDto> Execute(long Id);
    }
}

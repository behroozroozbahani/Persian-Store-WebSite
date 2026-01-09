using Store_Website.Common.Dto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdminService
    {
        ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20);
    }
}

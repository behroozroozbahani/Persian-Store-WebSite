using Store_Website.Domain.Entities.Products;
using Store_Website.Domain.Entities.Users;
using System.Collections.Generic;

namespace Store_Website.Application.Services.Products.Queries.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ProductsFormAdminList_Dto> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}

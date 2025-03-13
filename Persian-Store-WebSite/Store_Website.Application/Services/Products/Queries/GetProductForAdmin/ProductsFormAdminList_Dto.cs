using Store_Website.Domain.Entities.Products;
using System.Collections.Generic;

namespace Store_Website.Application.Services.Products.Queries.GetProductForAdmin
{
    public class ProductsFormAdminList_Dto
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
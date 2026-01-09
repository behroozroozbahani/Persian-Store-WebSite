using Store_Website.Domain.Entities.Products;

namespace Store_Website.Application.Services.Products.Commands.EditProduct
{
    public class RequestEditProductDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
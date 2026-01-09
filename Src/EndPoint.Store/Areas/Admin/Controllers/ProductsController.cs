using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Website.Application.Interfaces.FacadPatterns;
using Store_Website.Application.Services.Products.Commands.AddNewProduct;
using Store_Website.Application.Services.Products.Commands.EditCategory;
using Store_Website.Application.Services.Products.Commands.EditProduct;
using Store_Website.Domain.Entities.Products;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "مدیر, اپراتور")]
    public class ProductsController : Controller
    {

        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_productFacad.GetProductForAdminService.Execute(Page, PageSize).Data);
        }

        public IActionResult Detail(long Id)
        {
            return View(_productFacad.GetProductDetailForAdminService.Execute(Id).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacad.AddNewProductService.Execute(request));
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Edit(RequestEditProductDto request)
        {
            return Json(_productFacad.EditProductService.Execute(new RequestEditProductDto
            {
                ProductId = request.ProductId,
                Name = request.Name,
                CategoryId = request.CategoryId,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                Inventory = request.Inventory,
                Displayed = request.Displayed
            }));
        }

        [HttpPost]
        public IActionResult Delete(long ProductId)
        {
            return Json(_productFacad.RemoveProductService.Execute(ProductId));
        }
    }
}

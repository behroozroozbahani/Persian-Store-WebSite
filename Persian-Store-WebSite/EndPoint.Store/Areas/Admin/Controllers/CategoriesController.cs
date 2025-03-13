using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_Website.Application.Interfaces.FacadPatterns;
using Store_Website.Application.Services.Products.Commands.EditCategory;
using Store_Website.Application.Services.Users.Commands.EditUser;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "مدیر, اپراتور")]
    public class CategoriesController : Controller
    {

        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }


        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Edit(long CategoryId, string Name)
        {
            return Json(_productFacad.EditCategoryService.Execute(new RequestEditCategoryDto
            {
                CategoryId = CategoryId,
                Name = Name
            }));
        }

        [HttpPost]
        public IActionResult Delete(long CategoryId)
        {
            return Json(_productFacad.RemoveCategoryService.Execute(CategoryId));
        }
    }
}
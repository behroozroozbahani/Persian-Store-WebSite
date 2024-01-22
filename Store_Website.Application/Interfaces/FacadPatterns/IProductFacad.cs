using Store_Website.Application.Services.Products.Commands.AddNewCategory;
using Store_Website.Application.Services.Products.Commands.AddNewProduct;
using Store_Website.Application.Services.Products.Queries.GetAllCategories;
using Store_Website.Application.Services.Products.Queries.GetCategories;
using Store_Website.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Store_Website.Application.Services.Products.Queries.GetProductDetailForSite;
using Store_Website.Application.Services.Products.Queries.GetProductForAdmin;
using Store_Website.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Website.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}

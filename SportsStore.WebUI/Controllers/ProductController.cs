using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository reopository;

        public int PageSize = 4;

        public ProductController(IProductsRepository productsRepository) {
            this.reopository = productsRepository;
        }

        public ActionResult List(int page =1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = reopository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = reopository.Products.Count()
                }
            };
            
            return View(model);
        }
    }
}
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

        public ActionResult List(string category, int page =1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = reopository.Products
                .Where(p=>category ==null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null? reopository.Products.Count():
                    reopository.Products.Where(e=>e.Category == category).Count()
                },
                CurrentCategory = category
            };
            
            return View(model);
        }
    }
}
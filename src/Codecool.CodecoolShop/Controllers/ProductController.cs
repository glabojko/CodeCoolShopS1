using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Domain;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Models;
//using X.PagedList;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

       

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance()
                );
        }    

        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory(1);
            return View(products.ToList());
        }

        //public IActionResult Index(int? page)
        //{
        //    int pageNumber = page ?? 1;
        //    int pageSize = 12;

        //    List<Product> products = (List<Product>)ProductService.GetProductsForCategory(1);
        //    IPagedList<Product> pagedProducts = products.ToPagedList(pageNumber, pageSize);
        //    return View(pagedProducts);
        //}

        public IActionResult Categories(int category = 1)
        {

            var products = ProductService.GetProductsForCategory(category);
            return View( products.ToList());
        }

        public IActionResult Suppliers(int supplier)
        {
            var products = ProductService.GetProductsForSupplier(supplier);
            return View(products.ToList());
        }

        public IActionResult Cart()
        {
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

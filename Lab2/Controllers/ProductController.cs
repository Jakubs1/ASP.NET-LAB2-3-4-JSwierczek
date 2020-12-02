using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult ListAll() => View(repository.Products);

        public ViewResult List(string category) => View(repository.Products.Where(p => p.Category == category));

        public IActionResult Index()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Lab2.Controllers;
using Microsoft.CodeAnalysis;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {

        private IProductRepository repository;
        public ApiProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        // Pobranie listy produktów 
        [HttpGet]
        public IEnumerable<Product> GetProducts() => repository.Products;


        // pobranie produktu po ID 

        [HttpGet("{IDProduct}")]
        public Product Get(int IDProduct) => repository.Products.FirstOrDefault(p => p.IDProduct == p.IDProduct);


        // Dodawanie produktu
        [HttpPost]
        public ActionResult<Product> SaveProduct(Product product)
        {
            repository.SaveProduct(product);
            return Ok(product);
        }

        //Edytowanie produktu
        [HttpPut]
        public ActionResult<Product> Edit(Product product)
        {
            repository.SaveProduct(product);
            return Ok(product);
        }

        // Usuwanie produktu 
        [HttpDelete("{IDProduct}")]
        public void Delete(int IDProduct) => repository.DeleteProduct(IDProduct);
             
    }
}


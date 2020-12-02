/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product> {     
            new Product { Name = "Piłka nożna", Price = 25, Category="sprzęt sportowy", IDProduct = 2, Description="Roteiro" },
            new Product { Name = "Deska surfingowa", Price = 179, Category="sprzęt sportowy", IDProduct = 3, Description="najlepsza"},
            new Product { Name = "Buty do biegania", Price = 95, Category="sprzęt sportowy", IDProduct = 1, Description="super szybkie"}, 
        }.AsQueryable<Product>();
    
    }
}







*//*
 * public class TestRepository : ITestRepository
    {
        public IEnumerable<TestModel> GetItems()
        {
            return new List<TestModel>() {

            new TestModel {ProductName = "banan", ProductDescription = "owoc", ProductPrice = 2.50m },
            new TestModel { ProductName = "pomidor", ProductDescription = "warzywo", ProductPrice = 1m },
            new TestModel { ProductName = "pieprz", ProductDescription = "przyprawa", ProductPrice = 1.50m },
            new TestModel { ProductName = "tabasko", ProductDescription = "sos", ProductPrice = 4.50m },

            };
        }
    }
 */
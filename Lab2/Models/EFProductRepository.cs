using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly AppDbContext ctx;
        public EFProductRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<Product> Products => ctx.Products;

        public void SaveProduct(Product product)
        {
            if (product.IDProduct == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                Product dbEntry = ctx.Products
                    .FirstOrDefault(p => p.IDProduct == product.IDProduct);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            ctx.SaveChanges();
        }

        public Product DeleteProduct(int IDProduct)
        {
            Product dbEntry = ctx.Products
                .FirstOrDefault(p => p.IDProduct == IDProduct);
            if (dbEntry != null)
            {
                ctx.Products.Remove(dbEntry);
                ctx.SaveChanges();
            }
            return dbEntry;
        }

        public void CreateProduct(Product product)
        {
            ctx.Products.Add(new Product());
            ctx.SaveChanges();
        }

        public bool EditProduct(Product product)
        {
            Product dbEntry = ctx.Products.FirstOrDefault(p => p.IDProduct == product.IDProduct);

            if (dbEntry != null)
            {
                dbEntry.Name = product.Name;
                dbEntry.Description = product.Description;
                dbEntry.Price = product.Price;
                dbEntry.Category = product.Category;
            }
            else
            {
                return false;
            }
            ctx.SaveChanges();
            return true;
        }
    }
}

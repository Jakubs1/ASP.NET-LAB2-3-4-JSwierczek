using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get;  }
    }
}

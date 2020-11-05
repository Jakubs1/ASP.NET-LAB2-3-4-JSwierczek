using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Product
    {
        [Key]
        public int IDProduct
            
        {       
            get;
            set;
        }
        
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }
        
}
}

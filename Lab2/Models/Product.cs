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
        
        [Display(Name = "Nazwa")]
        public string Name
        {
            get;
            set;
        }

        [Display(Name = "Opis")]
        public string Description
        {
            get;
            set;
        }

        [Range (0.01, double.MaxValue, ErrorMessage = "Proszę dodać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public decimal Price
        {
            get;
            set;
        }

        [Display(Name = "Kategoria")]
        public string Category
        {
            get;
            set;
        }
    }
}

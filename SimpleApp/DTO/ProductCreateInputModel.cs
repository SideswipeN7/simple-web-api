using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.DTO
{
    public class ProductCreateInputModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        internal Product toProduct()
        {
            return new Product() { Name = Name, Price = Price };
        }
    }
}

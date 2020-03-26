using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp.DTO
{
    public class DtoProduct
    {
#if DEBUG
        public Guid Id { get; set; }
#endif
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
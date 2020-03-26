using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp.DTO
{
    public class DtoUpdateProduct
    {
        public Guid Guid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public override string ToString() => $"{{{nameof(DtoUpdateProduct)}:{nameof(Guid)}:{Guid},{nameof(Name)}:{Name},{nameof(Price)}:{Price}}}";
    }
}
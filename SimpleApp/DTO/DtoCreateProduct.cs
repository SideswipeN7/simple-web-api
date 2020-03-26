using System.ComponentModel.DataAnnotations;

namespace SimpleApp.DTO
{
    public class DtoCreateProduct
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public override string ToString() => $"{{{nameof(DtoCreateProduct)}:{nameof(Name)}:{Name},{nameof(Price)}:{Price}}}";
    }
}
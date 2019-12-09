using SimpleApp.DTO;
using SimpleApp.Interfaces;
using System;

namespace SimpleApp.Validators
{
    public class ProductUpdateValidator : IValidateProductUpdateInputModel
    {
        private readonly int MINIMAL_PRODUCT_NAME_LENGTH = 1;
        private readonly int MAXIMAL_PRODUCT_NAME_LENGTH = 100;
        private readonly int MINIMAL_PRODUCT_PRICE = 1;
        private readonly int MAXIMAL_PRODUCT_PRICE = 1_000_000;

        public bool Validate(ProductUpdateInputModel model, Guid id)
        {
            if (id == Guid.Empty)
            {
                Console.Error.WriteLine($"Product Guid is empty");
                return false;
            }
            if (model.Price < MINIMAL_PRODUCT_PRICE)
            {
                Console.Error.WriteLine($"Product Price is below minimal," +
                    $"is: {model.Price}, minimal is: {MINIMAL_PRODUCT_PRICE}");
                return false;
            }
            if (model.Price > MAXIMAL_PRODUCT_PRICE)
            {
                Console.Error.WriteLine($"Product Price is above maximal," +
                    $"is: {model.Price}, minimal is: {MAXIMAL_PRODUCT_PRICE}");
                return false;
            }
            if (model.Name.Length < MINIMAL_PRODUCT_NAME_LENGTH)
            {
                Console.Error.WriteLine($"Product Name is below minimal length," +
                    $"is: {model.Name.Length}, minimal is: {MAXIMAL_PRODUCT_NAME_LENGTH}");
                return false;
            }
            if (model.Name.Length > MAXIMAL_PRODUCT_NAME_LENGTH)
            {
                Console.Error.WriteLine($"Product Name is below minimal length," +
                    $"is: {model.Name.Length}, maximal is: {MAXIMAL_PRODUCT_NAME_LENGTH}");
                return false;
            }

            return true;
        }
    }
}

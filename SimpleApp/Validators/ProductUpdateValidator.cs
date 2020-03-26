using SimpleApp.DTO;
using SimpleApp.Interfaces;
using System;

namespace SimpleApp.Validators
{
    public class ProductUpdateValidator : IValidateProductUpdateInputModel
    {
        private readonly int MinimalProductNameLength = 1;
        private readonly int MaximalProductNameLength = 100;
        private readonly int MinimalProductPrice = 1;
        private readonly int MaximalProductPrice = 1_000_000;

        public ValidationResult Validate(DtoUpdateProduct model)
        {
            if (model.Guid == Guid.Empty)
            {
                return new ValidationResult { ErrorMessage = "Product Guid is empty" };
            }
            if (model.Price < MinimalProductPrice)
            {
                return new ValidationResult { ErrorMessage = $"Product Price is below minimal, is: {model.Price}, minimal is: {MinimalProductPrice}" };
            }
            if (model.Price > MaximalProductPrice)
            {
                return new ValidationResult { ErrorMessage = $"Product Price is above maximal, is: {model.Price}, minimal is: {MaximalProductPrice}" };
            }
            if (model.Name.Length < MinimalProductNameLength)
            {
                return new ValidationResult { ErrorMessage = $"Product Name is below minimal length, is: {model.Name.Length}, minimal is: {MaximalProductNameLength}" };
            }
            if (model.Name.Length > MaximalProductNameLength)
            {
                return new ValidationResult { ErrorMessage = $"Product Name is below minimal length, is: {model.Name.Length}, maximal is: {MaximalProductNameLength}" };
            }

            return new ValidationResult { IsSuccessful = true };
        }
    }
}
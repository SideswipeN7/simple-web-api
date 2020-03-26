using SimpleApp.DTO;
using SimpleApp.Interfaces;

namespace SimpleApp.Validators
{
    public class ProductCreateValidator : IValidateProductCreateInputModel
    {
        private const int MinimalProductNameLength = 1;
        private const int MaximalProductNameLength = 100;
        private const int MinimalProductPrice = 1;
        private const int MaximalProductPrice = 1_000_000;
        public ValidationResult Validate(DtoCreateProduct model)
        {
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
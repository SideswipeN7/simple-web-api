using SimpleApp.DTO;
using SimpleApp.Validators;

namespace SimpleApp.Interfaces
{
    public interface IValidateProductCreateInputModel
    {
        ValidationResult Validate(DtoCreateProduct model);
    }
}
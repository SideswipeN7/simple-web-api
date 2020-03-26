using SimpleApp.DTO;
using SimpleApp.Validators;

namespace SimpleApp.Interfaces
{
    public interface IValidateProductUpdateInputModel
    {
        ValidationResult Validate(DtoUpdateProduct model);
    }
}
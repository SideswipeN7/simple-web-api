using SimpleApp.DTO;

namespace SimpleApp.Interfaces
{
    public interface IValidateProductCreateInputModel
    {
        bool Validate(ProductCreateInputModel model);
    }
}

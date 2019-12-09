using SimpleApp.DTO;
using System;

namespace SimpleApp.Interfaces
{
    public interface IValidateProductUpdateInputModel
    {
        bool Validate(ProductUpdateInputModel model, Guid id);
    }
}

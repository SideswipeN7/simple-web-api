using SimpleApp.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleApp.Interfaces
{
    public interface IProductsService
    {
        Task<Guid> AddAsync(DtoCreateProduct model);
        Task<DtoProduct> DeleteAsync(Guid id);
        Task<IEnumerable<DtoProduct>> GetAsync();
        Task<DtoProduct> GetAsync(Guid id);
        Task<DtoProduct> UpdateAsync(DtoUpdateProduct model);
    }
}
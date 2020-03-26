using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleApp.DTO;
using SimpleApp.Interfaces;
using SimpleApp.Models;
using SimpleApp.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsContext dbContext;
        private readonly IValidateProductCreateInputModel createValidator;
        private readonly IValidateProductUpdateInputModel updateValidator;
        private readonly IMapper mapper;
        private readonly ILogger<ProductsService> logger;

        public ProductsService(IProductsContext dbContext,
                               IValidateProductCreateInputModel createValidator,
                               IValidateProductUpdateInputModel updateValidator,
                               IMapper mapper,
                               ILogger<ProductsService> logger)
        {
            this.dbContext = dbContext;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<DtoProduct>> GetAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<Product>, IEnumerable<DtoProduct>>(await dbContext.Products.ToListAsync());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error on {nameof(GetAsync)} in {nameof(ProductsService)}");

                throw;
            }
        }

        public async Task<DtoProduct> GetAsync(Guid id)
        {
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product is null)
                {
                    throw new NullReferenceException($"Not found product with id {id}");
                }

                return mapper.Map<Product, DtoProduct>(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error on {nameof(GetAsync)} in {nameof(ProductsService)} with Id: {id}");

                throw;
            }
        }

        public async Task<DtoProduct> DeleteAsync(Guid id)
        {
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product is null)
                {
                    throw new NullReferenceException($"Not found product with id {id}");
                }

                var result = dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();

                if (result.State != EntityState.Detached)
                {
                    throw new NotDeletedException(id);
                }

                return mapper.Map<Product, DtoProduct>(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error on {nameof(DeleteAsync)} in {nameof(ProductsService)} with id: {id}");

                throw;
            }
        }

        public async Task<Guid> AddAsync(DtoCreateProduct model)
        {
            try
            {
                ValidationResult validationResult = createValidator.Validate(model);
                if (!validationResult.IsSuccessful)
                {
                    throw new MissingDataException(validationResult.ErrorMessage);
                }


                Product product = mapper.Map<DtoCreateProduct, Product>(model);

                var result = await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();

                return result.Entity.Id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error on {nameof(AddAsync)} in {nameof(ProductsService)} Entity: {model}");

                throw;
            }
        }

        public async Task<DtoProduct> UpdateAsync(DtoUpdateProduct model)
        {
            try
            {
                ValidationResult validationResult = updateValidator.Validate(model);
                if (!validationResult.IsSuccessful)
                {
                    throw new MissingDataException(validationResult.ErrorMessage);
                }

                Product product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == model.Guid);
                if (product is null)
                {
                    throw new NullReferenceException($"Not found product with id {model.Guid}");
                }

                product.Name = model.Name;
                product.Price = model.Price;

                var result = dbContext.Products.Update(product);
                await dbContext.SaveChangesAsync();

                return mapper.Map<Product, DtoProduct>(result.Entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error on {nameof(UpdateAsync)} in {nameof(ProductsService)} Entity: {model}");

                throw;
            }
        }
    }
}
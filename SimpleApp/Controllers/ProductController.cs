using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.DTO;
using SimpleApp.Interfaces;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        public ProductsContext DbContext { get; set; }
        public IValidateProductCreateInputModel CreateValidator { get; set; }
        public IValidateProductUpdateInputModel UpdateValidator { get; set; }


        public ProductController(ProductsContext dbContext, IValidateProductCreateInputModel createValidator, IValidateProductUpdateInputModel updateValidator)
        {
            DbContext = dbContext;
            CreateValidator = createValidator;
            UpdateValidator = updateValidator;
        }


        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return DbContext.Products;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(Guid id)
        {
            return DbContext.Products.FirstOrDefault(e => e.Id == id);
        }

        // POST: api/Product
        [HttpPost]
        public Guid? Post([FromBody] ProductCreateInputModel model)
        {
            Guid? result = null;
            if (CreateValidator.Validate(model))
            {
                var product = model.toProduct();
                product = DbContext.Products.Add(product).Entity;
                DbContext.SaveChanges();
                result = product.Id;
            }

            return result;
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public Product Put(Guid id, [FromBody] ProductUpdateInputModel model)
        {
            Product result = null;
            if (UpdateValidator.Validate(model, id))
            {
                var toUpdate = DbContext.Products.FirstOrDefault(e => e.Id == id);
                if (toUpdate != null)
                {
                    toUpdate.Name = model.Name;
                    toUpdate.Price = model.Price;
                    DbContext.Products.Update(toUpdate);
                    DbContext.SaveChanges();
                    result = toUpdate;
                }
            }

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Product Delete(Guid id)
        {
            var toDelete = DbContext.Products.FirstOrDefault(e => e.Id == id);
            if (toDelete != null)
            {
                toDelete = DbContext.Products.Remove(toDelete).Entity;
                DbContext.SaveChanges();
            }

            return toDelete;
        }
    }
}

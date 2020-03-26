using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.DTO;
using SimpleApp.Interfaces;

namespace SimpleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductsService service;

        public ProductController(IProductsService service)
        {
            this.service = service;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var products = await service.GetAsync();
                if (products is null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var product = await service.GetAsync(id);
                if (product is null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DtoCreateProduct model)
        {
            try
            {
                Guid productId = await service.AddAsync(model);

                return Ok(productId);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Product/5
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] DtoUpdateProduct model)
        {
            try
            {
                DtoProduct product = await service.UpdateAsync(model);

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await service.DeleteAsync(id);
            if (result is null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }
    }
}
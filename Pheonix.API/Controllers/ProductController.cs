using Microsoft.AspNetCore.Mvc;
using Pheonix.Domain.Entities;
using Pheonix.Service.Interfaces;
using Pheonix.Service.Validators;
using Pheonix.W.Controllers;

namespace Pheonix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _productService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _productService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
                return NotFound();

            return Execute(() => _productService.Add<ProductValidator>(product).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            if (product == null)
                return NotFound();

            return Execute(() => _productService.Update<ProductValidator>(product));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _productService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }
    }
}
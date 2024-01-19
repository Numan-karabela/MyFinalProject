using Business.Abstract;
using Business.Concreet;
using DataAccess.Concreet.EntityFramework;
using Entities.Concreet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] 
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Succees)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.add(product);
            if (result.Succees)
            {
                return Ok();
            }
            return BadRequest(result);

        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Succees)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}

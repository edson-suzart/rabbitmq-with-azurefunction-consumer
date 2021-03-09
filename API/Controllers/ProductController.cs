using API.Models;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("sendQueue")]
        public IActionResult Post([FromBody] ProductModel productModel)
        {
            productModel.DateInsert = DateTime.Now;

            _productService.SendProductModelQueue(productModel);

            return Ok(
                new
                {
                    message = "Produto enviado para fila. "
                });
        } 
        
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            return "Projeto de estudo! ";
        }

    }
}

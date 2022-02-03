using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private JsonFileProductService productService { get; set; }

        public ProductsController(JsonFileProductService jsonFileProductService)
        {
            this.productService = jsonFileProductService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.productService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string ProductId, [FromQuery]int Rating)
        {
            this.productService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}

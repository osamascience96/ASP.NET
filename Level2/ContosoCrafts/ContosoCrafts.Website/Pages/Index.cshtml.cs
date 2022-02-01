using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonFileProductService _jsonFileProductService;

        public IEnumerable<Product> products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService jsonFileProductService)
        {
            _logger = logger;
            _jsonFileProductService = jsonFileProductService;
        }

        public void OnGet()
        {
            // Get All the Products from the service
            this.products = _jsonFileProductService.GetProducts();
        }
    }
}

using ContosoCrafts.Website.Models;
using System.Text.Json;

namespace ContosoCrafts.Website.Services
{
    public class JsonFileProductService
    {

        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            // LINQ
            var product = products.First(x => x.Id == productId);

            if(product.Ratings == null)
            {
                product.Ratings = new int[] {rating};
            }
            else
            {
                var ratings = product.Ratings.ToList();
                ratings.Add(rating);

                product.Ratings = ratings.ToArray();
            }

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true,
                }), products);
            }
        }
    }
}

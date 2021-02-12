using System.Linq;
using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DBContext dBContext;

        public ProductController(DBContext DBContext)
        {
            dBContext = DBContext;
        }

        [HttpPost]
        public IActionResult addProduct(Product product)
        {
            product.ID = System.Guid.NewGuid().ToString();

            dBContext.Add(product);
            dBContext.SaveChanges();

            return Ok(product);
        }

        [HttpGet("get-product/{barcode}")]
        public IActionResult getProductByBarcode(string barcode)
        {
            return Ok(dBContext.products.FirstOrDefault(x => x.barcode == barcode));
        }

        [HttpPost("add-catergory")]
        public IActionResult addcatergory(catergory catergory){
            catergory.id = System.Guid.NewGuid().ToString();

            dBContext.Add(catergory);
            dBContext.SaveChanges();

            return Ok(catergory);

        }

        [HttpGet("get-store-products")] 
        public IActionResult storeProducts(string catergoryID, string storeID ){
            var storeProducts = dBContext.storeProducts.Wshere(x => x.storeID == storeID && x.product.catergoryID == catergoryID).ToList();

            return Ok(storeProducts);
        }
    }
}

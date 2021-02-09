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
    }
}

using System.Linq;
using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly DBContext dBContext;

        public StoreController(DBContext DBContext)
        {
            dBContext = DBContext;
        }

        [HttpPost]
        public IActionResult addStore(Store store)
        {
            store.Id = System.Guid.NewGuid().ToString();
            dBContext.Add(store);
            dBContext.SaveChanges();

            return Ok(store);
        }




        [HttpGet]
        public IActionResult getStores()
        {
            return Ok(dBContext.stores.ToList());
        }

        [HttpGet("get-user-stores/{userID}")]
        public IActionResult getUserStores(string userID)
        {
            return Ok(dBContext.stores.Where(x => x.UserID == userID));
        }

        [HttpPost("add-store-product")]
        public IActionResult addStoreProduct(StoreProducts storeProduct)
        {
            storeProduct.id = System.Guid.NewGuid().ToString();

            dBContext.Add(storeProduct);
            dBContext.SaveChanges();

            return Ok(storeProduct);
        }

        [HttpPost("update-store-product")]
        public IActionResult updateStoreProduct(StoreProducts storeProduct)
        {
            dBContext.Update(storeProduct);
            dBContext.SaveChanges();

            return Ok(storeProduct);
        }
    }

}

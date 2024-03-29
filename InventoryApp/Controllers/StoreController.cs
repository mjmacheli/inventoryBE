﻿using System.Linq;
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
            store.id = System.Guid.NewGuid().ToString();
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
            return Ok(dBContext.stores.Where(x => x.userId == userID && x.isDeleted == false));
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
            StoreProducts product = dBContext.storeProducts.FirstOrDefault(x => x.id == storeProduct.id);
            product.sellingPrice = storeProduct.sellingPrice;
            product.stockPrice = storeProduct.stockPrice;
            product.quantity = storeProduct.quantity;
            product.minLevel = storeProduct.minLevel;
            dBContext.Update(product);
            dBContext.SaveChanges();

            return Ok(storeProduct);
        }

        [HttpPost("sale")]
        public IActionResult sell(sales sales) {
            sales.id = System.Guid.NewGuid().ToString();
            dBContext.Add(sales);
            dBContext.SaveChanges();

            return Ok(sales);
        }

        [HttpGet("total-sales/{storeId}")]
        public IActionResult totalSales(string storeId)
        {
            return Ok(dBContext.sales.Where(x => x.storeID == storeId));
        }

        [HttpGet("all-sales")]
        public IActionResult allSales(string storeId)
        {
            return Ok(dBContext.sales.ToList());
        }

        [HttpDelete("/{storeId}")]
        public IActionResult RemoveStore(string storeId)
        {
            var store = dBContext.stores.FirstOrDefault(s => s.id == storeId);
            store.isDeleted = true;
            dBContext.Update(store);
            dBContext.SaveChanges();
            return Ok(store);
        }
    }

}

﻿using System.Linq;
using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            product.id = System.Guid.NewGuid().ToString();

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
        public IActionResult addCatergory(catergory catergory){
            catergory.id = System.Guid.NewGuid().ToString();

            dBContext.Add(catergory);
            dBContext.SaveChanges();

            return Ok(catergory);

        }

        [HttpGet("get-store-products")] 
        public IActionResult storeProducts(string catergoryID, string storeID ){
            var storeProducts = dBContext.storeProducts.Where(x => x.storeID == storeID && x.product.catergoryID == catergoryID).ToList();

            List<StoreProducts> products = new List<StoreProducts>();
            foreach(StoreProducts product in storeProducts){
                product.product = dBContext.products.FirstOrDefault(x => x.id == product.productID);
                products.Add(product);
            }
            return Ok(products);
        }

        [HttpGet("get-store-product-by-barcode")] 
        public IActionResult storeProduct(string barcode, string storeID ){
            var storeProducts = dBContext.storeProducts.Where(x => x.storeID == storeID && x.product.barcode == barcode).ToList();

            List<StoreProducts> products = new List<StoreProducts>();
            foreach(StoreProducts product in storeProducts){
                product.product = dBContext.products.FirstOrDefault(x => x.id == product.productID);
                products.Add(product);
            }
            return Ok(products);
        }

        [HttpGet("get-store-catergory")] 
        public IActionResult storeCategories(string storeID ){
            var storeProducts = dBContext.storeProducts.Where(x => x.storeID == storeID).ToList();

            List<catergory> catergories = new List<catergory>();
            foreach(StoreProducts product in storeProducts){
                product.product = dBContext.products.FirstOrDefault(x => x.id == product.productID);
                catergory catergory = dBContext.catergories.FirstOrDefault(x => x.id == product.product.catergoryID);
                catergories.Add(catergory);
            }
            return Ok(catergories);
        }
    }
}

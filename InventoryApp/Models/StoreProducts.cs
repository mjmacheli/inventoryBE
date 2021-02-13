using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Models
{
    public class StoreProducts
    {
        public string id { get; set; }
        public double sellingPrice { get; set; }
        public double stockPrice { get; set; }
        public int quantity { get; set; }

        [ForeignKey("storeID")]
        public string storeID { get; set; }
        public Store store { get; set; }

        [ForeignKey("productID")]
        public string productID { get; set; }
        public Product product { get; set; }
    }
}

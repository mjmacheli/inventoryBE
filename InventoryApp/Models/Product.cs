using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string barcode { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }

        [ForeignKey("catergory")]
        public string catergoryID { get; set; }
        public catergory catergory { get; set; }

    }
}

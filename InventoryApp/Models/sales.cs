using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Models
{
    public class sales
    {
        public string id { get; set; }
        public string totalSale { get; set; }
        public string totalCost { get; set; }

        [ForeignKey("store")]
        public string storeID { get; set; }
        public virtual Store store { get; set; }
    }
}
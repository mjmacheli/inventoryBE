using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InventoryApp.Models
{
    public class User
    {
        public string id { get; set; }

        public string names { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string dob { get; set; }

        public string country { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string area { get; set; }

        public string street { get; set; }

    }
}

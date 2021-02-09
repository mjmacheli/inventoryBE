using System;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InventoryApp.Models
{
    public class Store
    {
        public string Id { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string dob { get; set; }

        public string country { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string area { get; set; }

        public string street { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual User User { get; set; }

    }
}

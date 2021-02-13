using System;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InventoryApp.Models
{
    public class Store
    {
        public string Id { get; set; }

        public string name { get; set; }

        public string number { get; set; }

        public string streetName { get; set; }

        public int code { get; set; }
        public string province { get; set; }

        public string city { get; set; }

        public string area { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

    }
}

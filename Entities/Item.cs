using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using WinFormsApp1.Entities;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp1.Models
{
    [Alias("item")]
    public partial class Item : IEntity
    {
        public Item(Guid id, string name,
            float price, int quantity,
            float rate, string dealerName)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.rate = rate;
            this.dealerName = dealerName;
        }
        [NonChange]
        [Alias("item_id")]
        public Guid id { get; set; }
        [Alias("item_name")]
        public string name { get; set; }
        [Alias("cost")]
        [Filterable]
        public float price { get; set; }
        [Alias("count")]
        [Filterable]
        public int quantity { get; set; }
        [Alias("rate")]
        [Filterable]
        public float rate { get; set; }
        [Alias("dealer_name")]
        [NonChange]
        public string dealerName { get; set; }
        public string GetEntityName() { return "Item"; }

    }
}

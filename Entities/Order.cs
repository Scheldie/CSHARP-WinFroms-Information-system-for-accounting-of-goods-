using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Models
{
    [Alias("orders")]
    public partial class Order : IEntity
    {
        [NonChange]
        [Alias("order_id")]
        public Guid id { get; set; }
        [Alias("user_id")]
        [NonChange]
        public string user_id { get; set; }
        [Alias("final_cost")]
        [Filterable]
        public float finalCost { get; set; }
        [Alias("count")]
        [Filterable]
        public int itemsQuantity { get; set; }
        [Alias("final_place")]
        public string finalPlace { get; set; }
        [Alias("order_id")]
        [NonChange]
        public string name { get; set; }
        public Order() { }
        public Order(Guid id, string user_id, float price,
            int itemsQuantity, string finalPlace)
        {
            this.id = id;
            this.user_id = user_id;
            this.finalCost = price;
            this.itemsQuantity = itemsQuantity;
            this.finalPlace = finalPlace;
            this.name = id.ToString();
        }
        public string GetEntityName() { return "Order"; }
    }
}

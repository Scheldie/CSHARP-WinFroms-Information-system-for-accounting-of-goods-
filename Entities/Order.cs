using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Models
{
    public partial class Order : IEntity
    {
        public Guid id { get; set; }
        public string user_id { get; set; }
        public float finalCost { get; set; }
        public int itemsQuantity { get; set; }
        public string finalPlace { get; set; }
        public string name { get; set; }

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

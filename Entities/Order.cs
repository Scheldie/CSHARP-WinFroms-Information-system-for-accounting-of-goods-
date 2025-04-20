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
        public float finalCost { get; set; }
        public int itemsQuantity { get; set; }
        public string finalPlace { get; set; }

        public Order(Guid id, float price,
            int itemsQuantity, string finalPlace)
        {
            this.id = id;
            this.finalCost = price;
            this.itemsQuantity = itemsQuantity;
            this.finalPlace = finalPlace;
        }
        public string GetEntityName() { return "Order"; }
    }
}

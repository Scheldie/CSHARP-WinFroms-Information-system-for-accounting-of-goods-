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
        public Guid id { get; set; }
        
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public float rate { get; set; }
        public string dealerName { get; set; }
        public string GetEntityName() { return "Item"; }

    }
}

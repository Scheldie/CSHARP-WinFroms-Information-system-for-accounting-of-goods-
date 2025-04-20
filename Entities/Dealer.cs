using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Models
{
    [Alias("dealer")]
    public partial class Dealer : IEntity
    {
        public Dealer() { }
        public Dealer(Guid id, string name, string url, float rate)
        {
            this.id = id;
            this.name = name;
            this.url = url;
            this.rate = rate;
        }
        [NonChange]
        [Alias("dealer_id")]
        public Guid id { get; set; }
        [Alias("dealer_name")]
        public string name { get; set; }
        [Alias("url")]
        public string url { get; set; }
        [Alias("rate")]
        public float rate { get; set; }
        public string GetEntityName() { return "Dealer"; }
    }
}

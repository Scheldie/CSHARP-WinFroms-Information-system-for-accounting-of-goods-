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
    public partial class Dealer : IEntity
    {
        public Dealer(Guid id, string name, string url, float rate)
        {
            this.id = id;
            this.name = name;
            this.url = url;
            this.rate = rate;
        }
        public Guid id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public float rate { get; set; }
        public string GetEntityName() { return "Dealer"; }
    }
}

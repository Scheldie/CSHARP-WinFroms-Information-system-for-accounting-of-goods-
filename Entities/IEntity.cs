using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entities
{
    public partial interface IEntity
    {
        
        public Guid id { get; set; }
        public string name { get; set; }
        string GetEntityName();
    }
    public class NonChangeAttribute : Attribute
    {

    }
    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string text) 
        {
            Alias = text;
        }
        public string Alias { get; set; }
    }
    public class FilterableAttribute : Attribute
    {

    }
     
}

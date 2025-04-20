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
        string GetEntityName();
    }
    public class NonChangeAttribute : Attribute
    {

    }
}

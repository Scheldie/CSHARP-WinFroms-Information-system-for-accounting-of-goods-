using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Forms
{
    public partial interface ISaveChanges
    {
        public void SaveChanges(IEntity entity) { }
    }
    
}

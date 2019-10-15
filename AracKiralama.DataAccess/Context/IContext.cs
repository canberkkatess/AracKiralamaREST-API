using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Context
{
   public abstract class IContext:DbContext
    {
        public IContext() : base("Hastane_RandevuEntities")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }


    }
}

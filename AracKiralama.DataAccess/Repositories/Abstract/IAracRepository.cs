using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface IAracRepository : IRepository<tblArac, int>
    {

        IEnumerable<AracKmGor1_Result> AracKmGor(int aracID);

        IEnumerable<tblArac> SirketAracGetir(int sirketID);



    }
}

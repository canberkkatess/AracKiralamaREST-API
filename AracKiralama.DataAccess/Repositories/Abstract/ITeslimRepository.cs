using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface ITeslimRepository : IRepository<tblTeslim, int>
    {
        System.Data.Entity.Core.Objects.ObjectResult<int?> KmSiniriGecenAracSayisi(int sirketID,DateTime tarih);
        IEnumerable<long?> KilometreDondur(int aracID);

    }
}

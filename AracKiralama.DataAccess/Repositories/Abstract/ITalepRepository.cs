using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface ITalepRepository : IRepository<tblTalep, int>
    {

        IEnumerable<tblTalep> SirketTalepGetir(int sirketID);
        IEnumerable<tblTalep> MusteriTalepGetir(int musteriID);

    }
}

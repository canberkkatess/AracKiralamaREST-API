using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface IMusteriRepository : IRepository<tblMusteri, int>
    {
        void musteriEkle(tblMusteri m);

        int Login(string email, string sifre);
        string MD5eDonustur(string metin);
    }
}

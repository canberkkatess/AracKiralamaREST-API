using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface ISirketRepository : IRepository<tblSirket, int>
    {
        void sirketEkle(tblSirket a);
       
        int Login(string email, string sifre);


    }
}

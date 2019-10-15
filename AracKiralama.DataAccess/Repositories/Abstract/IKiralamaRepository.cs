using AracKiralama.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface IKiralamaRepository : IRepository<tblKiralama, int>
    {
        
        System.Data.Entity.Core.Objects.ObjectResult<int?> AylıkVergiGetir(int sirketID);
        System.Data.Entity.Core.Objects.ObjectResult<int?> ToplamKazancGetir(int sirketID);
        System.Data.Entity.Core.Objects.ObjectResult<int?> AylikNetKarGetir(int sirketID);
        System.Data.Entity.Core.Objects.ObjectResult<int?> GunlukKiralamaSayisi( DateTime tarih, int sirketID);

        IEnumerable<AylıkKazanclar1_Result> AylıkKazanclarVerileri(int sirketID);

        IEnumerable<int?> GelirDondur(int sirketID );
        IEnumerable<tblKiralama> SirketKiralamaGetir(int sirketID);
        IEnumerable<tblKiralama> KullaniciKiralamaGetir(int kullaniciID);




    }

    
}

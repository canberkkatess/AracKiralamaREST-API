using AracKiralama.Data;
using AracKiralama.DataAccess.Context;
using AracKiralama.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Concrate
{
    public class KiralamaRepository : Repository<tblKiralama, int>, IKiralamaRepository
    {

        private Hastane_RandevuEntities db = new Hastane_RandevuEntities();
        private KiralamaContext _dbContext;
        public KiralamaRepository(KiralamaContext context) : base(context)
        {
            _dbContext = context;
        }

      
       public  System.Data.Entity.Core.Objects.ObjectResult<int?> AylıkVergiGetir(int sirketID)
        {
            return db.AylıkVergi2(sirketID);
        }

        public System.Data.Entity.Core.Objects.ObjectResult<int?> AylikNetKarGetir(int sirketID)
        {
           return db.AylıkNetKar2(sirketID);
           

        }



        public System.Data.Entity.Core.Objects.ObjectResult<int?> ToplamKazancGetir(int sirketID)
        {
            return db.AylıkToplamKazanc1(sirketID); 
            

        }
        public System.Data.Entity.Core.Objects.ObjectResult<int?> GunlukKiralamaSayisi(DateTime tarih, int sirketID)
        {
            return db.GunlukKiralamalar1(tarih, sirketID);

        }
        public IEnumerable<int?> GelirDondur(int sirketID)
        {
            List<int?> gelirler = new List<int?>();

            var gelir = _dbContext.Kiralamalar.Where(x => x.sirketID == sirketID).ToList();
            

            foreach (var randevu1 in gelir)
            {
                gelirler.Add(randevu1.toplamUcret);
            }

            return gelirler;

        }

        public IEnumerable<tblKiralama> SirketKiralamaGetir(int sirketID)
        {
            var kiralamalar = _dbContext.Kiralamalar.Where(x => x.sirketID == sirketID).ToList();

            return kiralamalar;
        }
        public IEnumerable<tblKiralama> KullaniciKiralamaGetir(int kullaniciID)
        {
            var kiralamalar = _dbContext.Kiralamalar.Where(x => x.musteriID == kullaniciID).ToList();

            return kiralamalar;
        }

        public IEnumerable<AylıkKazanclar1_Result> AylıkKazanclarVerileri(int sirketID)
        {
            

            return db.AylıkKazanclar1(sirketID);
        }
    }
}

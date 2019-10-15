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
    public class TeslimRepository : Repository<tblTeslim, int>, ITeslimRepository
    {

        private Hastane_RandevuEntities db = new Hastane_RandevuEntities();
        private TeslimContext _dbContext;
        public TeslimRepository(TeslimContext context) : base(context)
        {
            _dbContext = context;
        }

        public System.Data.Entity.Core.Objects.ObjectResult<int?> KmSiniriGecenAracSayisi(int sirketID,DateTime tarih)
        {
            return db.GunlukKmSiniriAsanAracSayisi1(sirketID, tarih);
        }

        public IEnumerable<long?> KilometreDondur(int aracID)
        {
            List<long?> kilometreler = new List<long?>();

            var km = _dbContext.Teslimler.Where(x => x.aracID == aracID).ToList();


            foreach (var km1 in km)
            {
                kilometreler.Add(km1.kullanilanKm);
            }

            return kilometreler;

        }


    }
}

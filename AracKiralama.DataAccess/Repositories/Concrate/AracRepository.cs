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
   public  class AracRepository : Repository<tblArac, int>, IAracRepository
    {

        private Hastane_RandevuEntities db = new Hastane_RandevuEntities();
        private AracContext _dbContext;
        public AracRepository(AracContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<AracKmGor1_Result> AracKmGor(int aracID)
        {
            return db.AracKmGor1(aracID);
        }

        public IEnumerable<tblArac> SirketAracGetir(int sirketID)
        {
            var araclar = _dbContext.Araclar.Where(x => x.sirketID == sirketID).ToList();

            return araclar;
        }
    }
}

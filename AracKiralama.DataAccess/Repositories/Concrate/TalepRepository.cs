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
    public class TalepRepository : Repository<tblTalep, int>, ITalepRepository
    {

        private Hastane_RandevuEntities db = new Hastane_RandevuEntities();
        private TalepContext _dbContext;
        public TalepRepository(TalepContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<tblTalep> MusteriTalepGetir(int musteriID)
        {
            var talepler = _dbContext.Talepler.Where(x => x.musteriID == musteriID).ToList();

            return talepler;
        }

        public IEnumerable<tblTalep> SirketTalepGetir(int sirketID)
        {
          

                var talepler = _dbContext.Talepler.Where(x => x.sirketID == sirketID).ToList();

                return talepler;
            
        }
    }
}

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
    public class PuanRepository : Repository<tblPuan, int>, IPuanRepository
    {

        private Hastane_RandevuEntities db = new Hastane_RandevuEntities();
        private PuanContext _dbContext;
        public PuanRepository(PuanContext context) : base(context)
        {
            _dbContext = context;
        }


    }
}

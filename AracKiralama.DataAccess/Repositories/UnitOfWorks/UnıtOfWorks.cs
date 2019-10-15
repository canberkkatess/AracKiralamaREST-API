using AracKiralama.DataAccess.Context;
using AracKiralama.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusteriContext _musteriContext;
        private readonly AracContext _aracContext;
        private readonly KiralamaContext _kiralamaContext;
        private readonly PuanContext _puanContext;
        private readonly SirketContext _sirketContext;
        private readonly TalepContext _talepContext;
        private readonly TeslimContext _teslimContext;


        public IMusteriRepository MusteriRepository { get; private set; }

        public IAracRepository AracRepository { get; private set; }

        public IKiralamaRepository KiralamaRepository { get; private set; }

        public IPuanRepository PuanRepository { get; private set; }

        public ISirketRepository SirketRepository { get; private set; }

        public ITalepRepository TalepRepository { get; private set; }

        public ITeslimRepository TeslimRepository { get; private set; }

        public UnitOfWork(MusteriContext context)
        {
            _musteriContext = context;
            MusteriRepository = new AracKiralama.DataAccess.Repositories.Concrate.MusteriRepository(_musteriContext);
        }
        public UnitOfWork(AracContext context)
        {
            _aracContext = context;
            AracRepository = new AracKiralama.DataAccess.Repositories.Concrate.AracRepository(_aracContext);
        }
        public UnitOfWork(KiralamaContext context)
        {
            _kiralamaContext = context;
            KiralamaRepository = new AracKiralama.DataAccess.Repositories.Concrate.KiralamaRepository(_kiralamaContext);
        }
        public UnitOfWork(PuanContext context)
        {
            _puanContext = context;
            PuanRepository = new AracKiralama.DataAccess.Repositories.Concrate.PuanRepository(_puanContext);
        }
        public UnitOfWork(SirketContext context)
        {
            _sirketContext = context;
            SirketRepository = new AracKiralama.DataAccess.Repositories.Concrate.SirketRepository(_sirketContext);
        }
        public UnitOfWork(TalepContext context)
        {
            _talepContext = context;
            TalepRepository = new AracKiralama.DataAccess.Repositories.Concrate.TalepRepository(_talepContext);
        }
        public UnitOfWork(TeslimContext context)
        {
            _teslimContext = context;
            TeslimRepository = new AracKiralama.DataAccess.Repositories.Concrate.TeslimRepository(_teslimContext);
        }



        public void Commit()
        {
            if (_musteriContext != null)
            {
                _musteriContext.SaveChanges();
            }
            if (_aracContext != null)
            {
                _aracContext.SaveChanges();
            }
            if (_kiralamaContext != null)
            {
                _kiralamaContext.SaveChanges();
            }
            if (_puanContext != null)
            {
                _puanContext.SaveChanges();
            }
            if (_sirketContext != null)
            {
                _sirketContext.SaveChanges();
            }
            if (_talepContext != null)
            {
                _talepContext.SaveChanges();
            }
            if (_teslimContext != null)
            {
                _teslimContext.SaveChanges();
            }
        }

        public void Dispose()
        {
        }
    }
}

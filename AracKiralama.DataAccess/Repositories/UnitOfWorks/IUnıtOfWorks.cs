using AracKiralama.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IMusteriRepository MusteriRepository { get; }
        IAracRepository AracRepository { get; }
        IKiralamaRepository KiralamaRepository { get; }
        IPuanRepository PuanRepository { get; }
        ISirketRepository SirketRepository { get; }
        ITalepRepository TalepRepository { get; }
        ITeslimRepository TeslimRepository { get; }


        void Commit();
    }
}

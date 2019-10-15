using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.DataAccess.Repositories.Abstract
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        //Genel Fonksiyon Deposu

        TEntity GetById(TKey id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
    }
}

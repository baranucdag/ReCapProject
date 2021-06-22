using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{                                           //bu interface daha sonra IEntityRepositoryBase'e implemente edilecek, ve db ile bağlantı kurulacak
    public interface IEntityRepository<T> where  T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Uptade(T entity);
        void Delete(T entity);
    }
}

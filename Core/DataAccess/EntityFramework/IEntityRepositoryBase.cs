using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{           
    public class IEntityRepositoryBase<TEntity,TDBContext>:IEntityRepository<T Entity>
        where TEntity:class,IEntity,new()
        where TDBContext : DBContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implentation of c#  (say delete things to the GarbageCollector when block finished )
            using (TDBContext context = new TDBContext())
            {
                var addedEntity = context.Entry(entity);    //get referance.
                addedEntity.State = EntityState.Added;      //referans will be added. 
                context.SaveChanges();                      //save changes. 

            }
        }

        public void Delete(TEntity entity)
        {
            using (TDBContext context = new TDBContext())
            {
                var deletedEntity = context.Entry(entity);    //get referance.
                deletedEntity.State = EntityState.Deleted;      //referans will be deleted. 
                context.SaveChanges();                        //save changes. 

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)  //that will return a single data
        {
            using (TDBContext context = new TDBContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TDBContext context = new TDBContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }               //if filter is null return all info, else return info according to filter
        }

        public void Uptade(TEntity entity)
        {
            using (TDBContext context = new TDBContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}

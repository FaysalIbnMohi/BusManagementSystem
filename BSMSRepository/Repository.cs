using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSMSEntity;
using BSMSRepository;

namespace BSMSInterface
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        DataContext context = new DataContext();
       
        // BSMSDBContext context = new BSMSDBContext();
        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }
    }
}

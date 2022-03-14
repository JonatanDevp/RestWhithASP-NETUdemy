using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            this.context = context;
            this.dataset = context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                this.dataset.Add(item);
                this.context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T FindById(long id)
        {
            return dataset.ToList().SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<T> GetAll()
        {
            return this.dataset.ToList();
        }

        public T Update(T item)
        {
            var result = this.dataset.FirstOrDefault(x => x.Id == item.Id);

            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(item);
                    this.context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return result = null;
            }
        }
        public void Delete(long id)
        {
            var result = this.dataset.SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    this.dataset.Remove(result);
                    this.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return this.dataset.Any(x => x.Id.Equals(id));
        }

    }
}

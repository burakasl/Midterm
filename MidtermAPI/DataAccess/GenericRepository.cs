using MidtermAPI.Context;
using MidtermAPI.Entities;

namespace MidtermAPI.DataAccess
{
    public abstract class GenericRepository<T> where T : class
    {
        protected AppDbContext dbContext = new AppDbContext();

        public void Add(T t)
        {
            dbContext.Add(t);
            dbContext.SaveChanges();
        }

        public abstract List<T> GetAll(int id);

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Remove(T t)
        {
            dbContext.Remove(t);
            dbContext.SaveChanges();
        }

        public void Update(T t)
        {
            dbContext.Update(t);
            dbContext.SaveChanges();
        }

        
    }
}

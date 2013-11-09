using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repositories
{
    public class DBAlbumsRepository:IRepository<Album>
    {
        private DbContext dbContext;
        private DbSet<Album> entitySet;

        public DBAlbumsRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Album>();
        }

        public Album Add(Album item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Album Update(int id, Album item)
        {
          //var item = this.entitySet.Find(id);
          //if (item != null)
          //{
          //    this.entitySet;
          //    this.dbContext.SaveChanges();
          //}
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var item = this.entitySet.Find(id);
            if (item != null)
            {
                this.entitySet.Remove(item);
                this.dbContext.SaveChanges();
            }
        }

        public void Delete(Album item)
        {
            throw new NotImplementedException();
        }

        public Album Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Album> All()
        {
            return this.entitySet;
        }

        public IQueryable<Album> Find(System.Linq.Expressions.Expression<Func<Album, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}

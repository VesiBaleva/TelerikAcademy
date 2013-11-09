using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repositories
{
    public class DBArtistsRepository:IRepository<Artist>
    {
        private DbContext dbContext;
        private DbSet<Artist> entitySet;

        public DBArtistsRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Artist>();
        }

        public Artist Add(Artist item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Artist Update(int id, Artist item)
        {
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

        public void Delete(Artist item)
        {
            throw new NotImplementedException();
        }

        public Artist Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Artist> All()
        {
            return this.entitySet;
        }

        public IQueryable<Artist> Find(System.Linq.Expressions.Expression<Func<Artist, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}

using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repositories
{
    public class DBSongsRepository:IRepository<Song>
    {
        private DbContext dbContext;
        private DbSet<Song> entitySet;

        public DBSongsRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Song>();
        }

        public Song Add(Song item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Song Update(int id, Song item)
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

        public void Delete(Song item)
        {
            throw new NotImplementedException();
        }

        public Song Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Song> All()
        {
            return this.entitySet;
        }

        public IQueryable<Song> Find(System.Linq.Expressions.Expression<Func<Song, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}

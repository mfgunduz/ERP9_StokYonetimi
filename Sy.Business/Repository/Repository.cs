using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sy.Core.Abstracts;
using Sy.DataAccess;

namespace Sy.Business.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity :class, IEntity<TKey>
    {
        private readonly StokDbContext _context;
        private readonly DbSet<TEntity> _table;
        public Repository()
        {
            _context = new StokDbContext();
            _table = _context.Set<TEntity>();
        }

        
        public int Delete(TEntity entity)
        {
            _table.Remove(entity);
            return this.save();
        }

        public TEntity GetById(TKey Id)
        {
            return _table.Find(Id);
        }

        public TKey insert(TEntity entity)
        {
            _table.Add(entity);
            this.save();
            return entity.Id;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
           return predicate == null ? _table : _table.Where(predicate);
        }

        public int save()
        {
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _table.AddOrUpdate(entity);
            return this.save();
        }
    }
}

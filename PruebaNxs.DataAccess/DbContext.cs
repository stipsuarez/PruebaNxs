using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PruebaNxs.Abstractions;

namespace PruebaNxs.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        DbSet<T> _items;
        ApiDbContext _context;

        public DbContext(ApiDbContext context)
        {
            _context = context;
            _items = _context.Set<T>();

        }
        public ApiDbContext GetDbContext()
        {
            return _context;
        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            _items.Remove(entity);
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Where(i=> i.id.Equals(id)).FirstOrDefault();
        }    

        public T Save(T entity)
        {
            _items.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

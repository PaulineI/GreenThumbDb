using GreenThumb.Migrations;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenThumb.Database
{
    public class PlantRepository<T> where T : class
    {
        private readonly PlantDbContext _context;
        private readonly DbSet<T> _dbSet;

        public PlantRepository(PlantDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        //public async Task Delete(int id)
        //{
        //    T? entityToRemove = await GetById(id);

        //    if (entityToRemove != null)
        //    {
        //        _dbSet.Remove(entityToRemove);
        //    }
        //}

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }
    }
}

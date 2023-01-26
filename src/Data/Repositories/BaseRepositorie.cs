using Data.Context;
using Domain.Entities;
using Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepositorie<T> : IBaseRepositorie<T> where T : Base
    {
        private readonly BancoContext _context;

        public BaseRepositorie(BancoContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            try
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var obj = await GetAsync(id);

                if (obj != null)
                {
                    _context.Remove(obj);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate: x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<Pagination<T>> GetAll(int pageIndex, int pageSize)
        {
            //return await _context.Set<T>().ToListAsync();
            var query = await _context.Set<T>().ToListAsync();
            return await Task.Run(() => Pagination<T>.Create(query.AsQueryable(), pageIndex, pageSize));
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                System.Diagnostics.Debug.WriteLine("[LOG]Böyle bir ürün yok");
            }
            return entity;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Silme işlemi başarısız böyle bir ürün yok");
            }
        }

    }
}

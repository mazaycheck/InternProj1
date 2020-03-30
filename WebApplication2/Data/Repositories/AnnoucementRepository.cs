using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data.Repositories
{
    public class AnnoucementRepository : IAnnoucementRepository
    {
        private readonly AppDbContext _context;

        public AnnoucementRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Annoucement entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Annoucements null");
            }
            await _context.Annoucements.AddAsync(entity);
            //await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var annoucement = await _context.FindAsync<Annoucement>(id);
            if (annoucement == null)
            {                
                throw new NullReferenceException("Not found");
            }
            _context.Annoucements.Remove(annoucement);
            //await _context.SaveChangesAsync();
        }

        public IQueryable<Annoucement> GetAll()
        {
            
            return _context.Annoucements.AsNoTracking();

        }
    
        public async Task<Annoucement> GetById(int id)
        {
            return await _context.Annoucements.FindAsync(id);
        }

        public async Task Update(Annoucement entity)
        {
            var annoucementToUpdate = await _context.Annoucements.FindAsync(entity.AnnoucementId);
            _context.Entry(annoucementToUpdate).CurrentValues.SetValues(entity);
            //await _context.SaveChangesAsync();
        }
        public async Task<int> Save()
        {
            var rowncount = await _context.SaveChangesAsync();
            return rowncount;
        }

        public async Task<int> DeleteAllFromUser(int id)
        {
            
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    //var annoucementsToDelete = await _context.Annoucements.Where(x => x.UserId == id).ToListAsync();
                    var rowcount = _context.Database.ExecuteSqlInterpolated($"DELETE FROM Annoucements WHERE UserId = {id}");
                    await trans.CommitAsync();
                    return rowcount;
                }
                catch (Exception e)
                {
                    await trans.RollbackAsync();
                    return 0;
                }
            }                                    
        }

  
    }
}

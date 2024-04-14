using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MassionRepository : IMassionRepository
    {
        private readonly ApplicationDbContext _context;

        public MassionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Massion?> AddTag(int mId, int tId)
        {
            var massion = await _context.Massions.FindAsync(mId);
            var tag = await _context.Tags.FindAsync(tId);
            if(massion == null || tag == null){
                return null;
            }
            massion.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return massion;
        }

        public async Task<Massion> Create(Massion massion)
        {
            await _context.Massions.AddAsync(massion);
            await _context.SaveChangesAsync();
            return massion;
        }

        public async Task<Massion?> Delete(int id)
        {
            var massion = await _context.Massions.FirstOrDefaultAsync(m => m.Id == id);
            if(massion == null){
                return null;
            }
            _context.Massions.Remove(massion);
            await _context.SaveChangesAsync();
            return massion;
        }

        public async Task<Massion?> DeleteTag(int mId, int tId)
        {
            var masionRes = await _context.Massions.Include(m => m.Tags).FirstOrDefaultAsync(m => m.Id == mId);
            var tagRes = await _context.Tags.FindAsync(tId);
            if(masionRes == null || tagRes == null){
                return null;
            }
            masionRes.Tags.Remove(tagRes);
            await _context.SaveChangesAsync();
            return masionRes;
        }

        public async Task<List<Massion>> GetAll()
        {
            return await _context.Massions.Include(m=>m.SubMissions).Include(m=>m.Tags).ToListAsync();
        }

        public async Task<Massion?> GetById(int id)
        {
            var massion = await _context.Massions.Include(m=>m.SubMissions).Include(m=>m.Tags).FirstOrDefaultAsync(m => m.Id == id);
            if(massion == null){
                return null;
            }
            return massion;
        }

        public async Task<List<Massion>> GetMassionsByUser(string uid)
        {
            var massions = await _context.Massions.Where(m => m.UserId == uid).ToListAsync();
            return massions;
        }

        public async Task<bool> IsMassionExist(int id)
        {
            var massion = await _context.Massions.FindAsync(id);
            if(massion == null){
                return false;
            }
            return true;
        }

        public async Task<Massion?> Update(int id, Massion massion)
        {
            var m = await _context.Massions.FirstOrDefaultAsync(m => m.Id == id);
            if(m == null){
                return null;
            }
            m.Title = massion.Title;
            m.Description = massion.Description;
            m.DueAt = massion.DueAt;
            m.Priority = massion.Priority;
            m.Status = massion.Status;

            await _context.SaveChangesAsync();
            return massion;
        }
    }
}
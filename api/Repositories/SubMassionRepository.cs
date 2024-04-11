using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace api.Repositories
{
    public class SubMassionRepository : ISubMassionRepository
    {

        private readonly ApplicationDbContext _context;

        public SubMassionRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task<SubMassion> Create(SubMassion subMassion)
        {
            await _context.SubMassions.AddAsync(subMassion);
            await _context.SaveChangesAsync();
            return subMassion;
        }

        public async Task<SubMassion?> Delete(int id)
        {
            var subMassion = await _context.SubMassions.FirstOrDefaultAsync(s => s.Id == id);
            if(subMassion == null){
                return null;
            }
            _context.SubMassions.Remove(subMassion);
            await _context.SaveChangesAsync();
            return subMassion;
        }

        public async Task<List<SubMassion>> GetAll()
        {
            return await _context.SubMassions.ToListAsync();
        }

        public async Task<SubMassion?> GetById(int id)
        {
            var subMassion = await _context.SubMassions.FindAsync(id);
            if(subMassion == null){
                return null;
            }
            return subMassion;
        }

        public async Task<SubMassion?> Update(int id, SubMassion subMassion)
        {
            var subMassionRes = await _context.SubMassions.FirstOrDefaultAsync(s => s.Id == id);
            if(subMassion == null){
                return null;
            }
            subMassionRes.Title = subMassion.Title;
            subMassionRes.Description = subMassion.Description;
            subMassionRes.Priority = subMassion.Priority;
            subMassionRes.Status = subMassion.Status;

            await _context.SaveChangesAsync();
            return subMassion;
        }
    }
}
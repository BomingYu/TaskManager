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
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Tag> Create(Tag tag)
        {
            await _context.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> Delete(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t=>t.Id == id);
            if(tag == null){
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _context.Tags.Include(t=>t.Massions).ThenInclude(m=>m.SubMissions).ToListAsync();
        }

        public async Task<Tag?> GetById(int id)
        {
            var tag = await _context.Tags.Include(t => t.Massions).ThenInclude(m=>m.SubMissions).FirstOrDefaultAsync(t=>t.Id == id);
            if(tag == null){
                return null;
            }
            return tag;
        }

        public async Task<Tag?> Update(int id, Tag tag)
        {
            var tagRes = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if(tagRes == null){
                return null;
            }
            tagRes.Name = tag.Name;
            tagRes.Color = tag.Color;

            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITagRepository
    {
        Task <List<Tag>> GetAll();
        Task <Tag?> GetById(int id);
        Task <Tag> Create(Tag tag);
        Task <Tag?> Update(int id , Tag tag);

        Task <Tag?> Delete(int id);
    }
}
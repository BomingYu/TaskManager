using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ISubMassionRepository
    {
        Task<List<SubMassion>> GetAll();
        Task<SubMassion?> GetById(int id);
        Task<SubMassion> Create(SubMassion subMassion);
        Task<SubMassion?> Delete(int id);

        Task<SubMassion?> Update(int id, SubMassion subMassion);
    }
}
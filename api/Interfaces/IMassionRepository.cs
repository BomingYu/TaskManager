using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IMassionRepository
    {
        Task <List<Massion>> GetAll();
        Task <Massion?> GetById(int id);
        Task <List<Massion>> GetMassionsByUser(string uid);

        Task <Massion> Create(Massion massion);

        Task <Massion?> Update(int id , Massion massion);

        Task <Massion?> Delete (int id);
        Task <Massion?> AddTag (int mId , int tId);
        Task <Massion?> DeleteTag(int mId , int tId);
        
        Task<bool> IsMassionExist(int id);
    }
}
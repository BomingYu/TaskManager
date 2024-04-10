using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task <List<User>> GetAll();
        Task <User?> GetById(int id);

        Task<bool> Existed(int id);
    }
}
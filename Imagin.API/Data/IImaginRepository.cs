using System.Threading.Tasks;
using System.Collections.Generic;
using Imagin.API.Models;

namespace Imagin.API.Data
{
    public interface IImaginRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
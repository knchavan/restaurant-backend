using System.Collections.Generic;
using restaurant_backend.Models;

namespace restaurant_backend.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
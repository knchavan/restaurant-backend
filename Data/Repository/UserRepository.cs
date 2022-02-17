using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;

namespace restaurant_backend.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
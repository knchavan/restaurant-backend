using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;

namespace restaurant_backend.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Restaurant = new RestaurantRepository(_db);
        }

        public IUserRepository User { get; private set; }

        public IRestaurantRepository Restaurant { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
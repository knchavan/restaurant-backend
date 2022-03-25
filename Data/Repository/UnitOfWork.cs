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
            Item = new ItemRepository(_db);
        }

        public IUserRepository User { get; private set; }

        public IRestaurantRepository Restaurant { get; private set; }
        public IItemRepository Item { get; set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using restaurant_backend.Models;

namespace restaurant_backend.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get;}
        void Save();
    }
}
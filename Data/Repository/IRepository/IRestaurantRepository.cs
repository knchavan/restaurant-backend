using restaurant_backend.Models;

namespace restaurant_backend.Data.Repository.IRepository
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        void Update(Restaurant restaurant);
    }
}
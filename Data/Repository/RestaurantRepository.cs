using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;

namespace restaurant_backend.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly ApplicationDbContext _db;
        public RestaurantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Restaurant restaurant)
        {
            _db.Restaurants.Update(restaurant);
        }
    }
}
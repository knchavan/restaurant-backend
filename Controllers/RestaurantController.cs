using Microsoft.AspNetCore.Mvc;
using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;

namespace restaurant_backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var restaurantList = _unitOfWork.Restaurant.GetAll();
            return Ok(restaurantList);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById(int id)
        {
            var restaurantFromDb = _unitOfWork.Restaurant.GetFirstOrDefault(r => r.Id == id);
            return Ok(restaurantFromDb);
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant) 
        {
            if (restaurant == null) return NotFound();
            _unitOfWork.Restaurant.Add(restaurant);
            _unitOfWork.Save();
            return CreatedAtRoute(nameof(GetById), new {id = restaurant.Id}, restaurant);
        }

        [HttpPut]
        public ActionResult Update(Restaurant restaurant)
        {
            if (restaurant == null) return NotFound();
            _unitOfWork.Restaurant.Update(restaurant);
            _unitOfWork.Save();
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var restaurantFromDb = _unitOfWork.Restaurant.GetFirstOrDefault(r => r.Id == id);
            if (restaurantFromDb == null) return NotFound();
            _unitOfWork.Restaurant.Remove(restaurantFromDb);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
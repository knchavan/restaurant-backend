using Microsoft.AspNetCore.Mvc;
using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;

namespace restaurant_backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var itemList = _unitOfWork.Item.GetAll();
            return Ok(itemList);
        }

        [HttpGet("{id}", Name = "GetByItemId")]
        public ActionResult GetByItemId(int id)
        {
            var itemFromDb = _unitOfWork.Item.GetFirstOrDefault(i => i.Id == id);
            return Ok(itemFromDb);
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (item == null) return NotFound();
            _unitOfWork.Item.Add(item);
            _unitOfWork.Save();
            return CreatedAtRoute(nameof(GetByItemId), new {id = item.Id}, item);
            // return Ok();
        }
    }
}
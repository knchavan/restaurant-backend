using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;

namespace restaurant_backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {   
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var userList = _unitOfWork.User.GetAll();
            return Ok(userList);
        }

        [HttpPost("signup")]
        public ActionResult SignUp(User user)
        {
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpPost("login")]
        public ActionResult Login(string email, string password)
        {
            var user = _unitOfWork.User.GetFirstOrDefault(u => u.Email == email && u.Password == password);
            return Ok(new {
                name = user.Name,
                email = user.Email
            });
        }
    }
}
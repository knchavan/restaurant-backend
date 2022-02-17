using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restaurant_backend.Data.Repository.IRepository;
using restaurant_backend.Models;
using restaurant_backend.Models.ViewModels;

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
            return Ok(new {
                id = user.Id,
                name = user.Name,
                email = user.Email
            });
        }

        [HttpPost("login")]
        public ActionResult Login(LoginUserVM loginUserVM)
        {
            var userFromDb = _unitOfWork.User.GetFirstOrDefault(u => u.Email == loginUserVM.Email && u.Password == loginUserVM.Password);
            if (userFromDb == null) return NotFound();
            return Ok(new {
                id = userFromDb.Id,
                name = userFromDb.Name,
                email = userFromDb.Email
            });
        }

    }
}
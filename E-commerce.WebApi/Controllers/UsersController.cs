using E_commerce.Repositiry;
using E_commerce.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_commerce.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserRepository userRepository;
        public UsersController()
        {
            userRepository = new UserRepository();
        }

        public UserRepository GetUserRepository()
        {
            return userRepository;
        }

        [HttpGet]
        public IHttpActionResult Get(int id, UserRepository userRepository)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new UserModel(user));
        }

        [HttpGet]
        public IHttpActionResult Get (string username)
        {
            var user = userRepository.Get(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new UserModel(user));
        }

        [HttpGet]
        public IHttpActionResult Login (string username, string password)
        {
            var user = userRepository.Get(username, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new UserModel(user));
        }

        [HttpPost]
        public IHttpActionResult Post(UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var user = new User
                (
                0, 
                model.Username, 
                model.Password, 
                model.Fullname, 
                model.Role
                );
             user = userRepository.Add(user);
            return Ok(new UserModel(user));
        }

        [HttpPut]
        public IHttpActionResult Put(UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var user = new User
                (
                model.Id,
                model.Username,
                model.Password,
                model.Fullname,
                model.Role
                );
            user = userRepository.Set(user);
            return Ok(new UserModel(user));
        }

    }
}

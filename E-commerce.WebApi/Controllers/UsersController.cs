using E_commerce.Models;
using E_commerce.Repositiry;
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
            return Ok(MapUser(user));
        }

        

        [HttpGet]
        public IHttpActionResult Get (string username)
        {
            var user = userRepository.Get(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(MapUser(user));
        }

        [HttpGet]
        public IHttpActionResult Login (string username, string password)
        {
            var user = userRepository.Get(username, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(MapUser(user));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]UserModel model)
        {
            try
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
                return Ok(MapUser(user));
            }


            catch (DuplicateWaitObjectException)
            {
                return Conflict();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(UserModel model)
        {
            try
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
                return Ok(MapUser(user));

            }

            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            catch (DuplicateWaitObjectException)
            {
                return Conflict();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private UserModel MapUser(User user)
        {
            return new UserModel
                                (
                                    user.Id,
                                    user.Username,
                                    user.Fullname,
                                    user.Role
                                );
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Mapper;
using WorkTask.Model;
using WorkTask.Repos;

namespace WorkTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IRepos<User> UserRep;
        private IMapper mapper;
        public UserController(IRepos<User> _UserRep, IMapper _mapper)
        {
            this.UserRep = _UserRep;
            this.mapper = _mapper;
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<UserDTO> Data = mapper.Map<List<UserDTO>>(UserRep.GetAll());
            return Ok(Data);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            UserDTO Data = mapper.Map<UserDTO>(UserRep.GetById(id));
            return Ok(UserRep.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post(User user)
        {
            UserRep.Create(user);
            return CreatedAtAction("Get", new { id = user.ID }, UserRep.GetAll());
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, User user)
        {
            UserRep.Modfiy(id, user);
            return Ok(UserRep.GetAll());
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            UserRep.Delete(id);
            return Ok(UserRep.GetAll());
        }
    }
}

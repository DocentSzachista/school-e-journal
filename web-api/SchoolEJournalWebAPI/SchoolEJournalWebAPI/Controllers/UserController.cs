using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolEJournalWebAPI.DataSchemas;
using SchoolEJournalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly SchoolEJournalDbContext _dbContext;

        public UserController(SchoolEJournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("getUsers")]
        public IActionResult Get()
        {
            try
            {
                var users = _dbContext.Users.ToList();
                if(users.Count == 0)
                {
                    return NotFound("No user found");
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
           
        }
        [HttpPost("createUser")]
        public IActionResult Create([FromBody] User user)
        {
            return Ok();
        }
        [HttpPost("updateUser")]
        public IActionResult Update([FromBody] User user)
        {
            return Ok();
        }

        [HttpDelete("deleteUser/{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok();
        }

    }
}

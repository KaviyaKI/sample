using learningprojectserver.models;
using learningprojectserver.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace learningprojectserver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        Userservice usersservice;

        public UserController(Userservice usersservice)
        {
            this.usersservice = usersservice;
        }

        [HttpPost("Select")]
        public async Task<ActionResult<List<Users>>> Select(Users req)
        {
              List<Users> result = new List<Users> ();

               //result = await usersservice.GetNames(req);

               return Ok(result);
        }

        [HttpPost("save")]
        public IActionResult SaveData([FromBody] TestModel data)
        {
            return Ok(new { message = "Data received successfully", data });
        }

        //[HttpPost("signup")]
        //public async Task<ActionResult<List<Signupreq>>> signup(Signupreq req)
        //{
        //    List<Users> result = new List<Users>();

        //    result = await usersservice.Signup(req);

        //    return Ok(result);
        //}
    }

    public class TestModel
    {
        public string Name { get; set; }
    }


}

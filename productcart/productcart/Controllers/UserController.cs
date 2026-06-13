using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcart.Dto;
using productcart.IDal;

namespace productcart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IUserDal _userdal) : ControllerBase
    {
        [HttpPost]
        public  IActionResult createUser(userDto userDto)
        {
           var user =  _userdal.CreateUser(userDto);
            return Ok("User Is Created");
        }

        [HttpPut]
        public IActionResult UpdateUser(userDto userDto)
        {
            var user = _userdal.UpdateUser(userDto);
            return Ok("User Is Updated");
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromRoute]int userId)
        {
            var user = _userdal.DeleteUser(userId);
            return Ok("User Is Deleted");
        }

        [HttpGet]
        public IActionResult GetUserById(int userId)
        {
            var user = _userdal.FetchUserById(userId);
            return Ok(user);
        }
    }
}

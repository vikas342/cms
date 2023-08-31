using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task__007.dtos;
using Task__007.Models;

namespace Task__007.Controllers
{
    [EnableCors("Policy1")]

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly Task007Context context;

        public UserController(Task007Context context)
        {
            this.context = context;
        }



        [HttpPost("signup")]
        public async Task<IActionResult> signup(signupDTO dto)
        {
            if(context.Users.FirstOrDefault((x)=> x.Email== dto.Email) != null)
            {
                return BadRequest("user alredy exist");

            }
            var data = new User();
            data.Email =dto.Email;
            data.Uname = dto.Uname;
            data.Password = dto.Password;
            data.Role = 2;


           context.Add(data);
            context.SaveChanges();
            return Ok(data);

        }



        [HttpPost("loging")]
        public async Task<IActionResult> login(loginDTO dto)
        {
            var data = context.Users.FirstOrDefault((x) => x.Email == dto.Email && x.Password == dto.Password);

          

           if (data != null)
            {
                return Ok(new { id=data.Uid,email=data.Email,role=data.Role});

            }
            else
            { 
                    return BadRequest("user not exist");
                 
            } 
        }

    }
}

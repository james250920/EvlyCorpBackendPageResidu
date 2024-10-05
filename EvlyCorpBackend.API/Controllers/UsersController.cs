using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EvlyCorpBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register( [FromBody] UsersInsertDTO usersInsertDTO)
        {
            if (usersInsertDTO.Email.IsNullOrEmpty() || usersInsertDTO.Password.IsNullOrEmpty())
                return BadRequest();
            
            var result = await _usersService.Register(usersInsertDTO);
            if (!result )
                return BadRequest("User already exists");

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginDTO usersLoginDTO)
        {
            if(usersLoginDTO.Email.IsNullOrEmpty() || usersLoginDTO.Password.IsNullOrEmpty())
                return BadRequest("Email and password are required");

            var user = await _usersService.Login(usersLoginDTO);
            if (user == null)
                return BadRequest("Invalid credentials");

            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _usersService.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _usersService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}

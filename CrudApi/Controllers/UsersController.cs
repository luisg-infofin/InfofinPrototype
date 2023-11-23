using AutoMapper;
using CrudApi.Contracts;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAbstractRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IAbstractRepository<User> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var allUsers = await _usersRepository.GetAsync();
                return Ok(allUsers);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _usersRepository.GetByIdAsync(id);
                
                if (user is null) return NotFound("User not found on database");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CraeteUser([FromBody]CreateUserDTO args)
        {
            try
            {
                var newUser = _mapper.Map<CreateUserDTO, User>(args);
                await _usersRepository.AddAsync(newUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserDto args)
        {
            try
            {
                var userOnDb = await _usersRepository.GetByIdAsync(id);

                if (userOnDb is null) return NotFound("User not found on database");

                userOnDb = _mapper.Map<UpdateUserDto, User>(args);

                await _usersRepository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var userOnDb = await _usersRepository.GetByIdAsync(id);

                if (userOnDb is null) return NotFound("User not found on database");


                await _usersRepository.DeleteAsync(userOnDb);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using AutoMapper;
using CrudApi.Contracts;
using Entities;
using Entities.BusEvents;
using Entities.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]    
    public class UsersController : ControllerBase
    {
        private readonly IAbstractRepository<User> _usersRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishProvider;

        public UsersController(IAbstractRepository<User> usersRepository, IMapper mapper, IPublishEndpoint publishProvider)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _publishProvider = publishProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(string? date)
        {
            try
            {
                var allUsers = await _usersRepository.GetAsync();

                if(!String.IsNullOrEmpty(date)) {
                    allUsers = allUsers.Where(x => x.UpdateAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
                    var result = _mapper.Map<List<User>, List<UserDTO>>(allUsers.ToList());                    
                    return Ok(result);
                }

                return Ok(_mapper.Map<List<User>, List<UserDTO>>(allUsers.ToList()));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CraeteUser([FromBody]CreateUserDTO args)
        {
            try
            {
                var newUser = _mapper.Map<CreateUserDTO, User>(args);
                newUser.CreatedAt = DateTime.Now;
                newUser.CreationUser = User?.Identity?.Name ?? "SYSTEM";  
                var userCreated = await _usersRepository.AddAsync(newUser);
                await _publishProvider.Publish(_mapper.Map<PersonCreated>(userCreated));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromQuery]Guid id, [FromBody] UpdateUserDto args)
        {
            try
            {
                var userOnDb = await _usersRepository.GetByIdAsync(id);

                if (userOnDb is null) return NotFound("User not found on database");

                userOnDb.Name = args.Name;
                userOnDb.Email = args.Email;
                userOnDb.Address = args.Address;
                userOnDb.UpdateAt = DateTime.Now;
                userOnDb.UpdateUser = User?.Identity?.Name ?? "SYSTEM";

                await _usersRepository.SaveChangesAsync();

                var personUpdatedEventEntity = _mapper.Map<PersonUpdated>(userOnDb);
                await _publishProvider.Publish(personUpdatedEventEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromQuery]Guid id)
        {
            try
            {
                var userOnDb = await _usersRepository.GetByIdAsync(id);
                if (userOnDb is null) return NotFound("User not found on database");

                await _usersRepository.DeleteAsync(userOnDb);
                await _publishProvider.Publish<PersonDeleted>(new PersonDeleted { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

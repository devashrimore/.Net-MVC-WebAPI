using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Repository;


namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDetails _user;
        private IMapper _mapper;
        public UserController(IUserDetails userService,IMapper mapper)
        {
            _user = userService;
            _mapper = mapper;

        }

        [HttpGet("AllUserDetails")]
        public IActionResult GetDetails()
        {
           
            var users= _user.GetAllUserDetails();
            //return DTO DATA

            /*var usersDTO = new List<Models.DTO.User>();
            users.ToList().ForEach(user =>
            {
                var userDTO = new Models.DTO.User()
                {
                    UserID = user.UserID,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                };
                usersDTO.Add(userDTO);
            });
            return Ok(usersDTO);*/

            var UsersDTO=_mapper.Map<List<Models.DTO.User>>(users);
            return Ok(UsersDTO);
        }

        // GET: api/Users/1
       [HttpGet("{id}")]
       [ActionName("GetUser")]
        public async Task<ActionResult> GetUser(int id)
        {
            var result = await _user.GetUser(id);
            if (result == null)
            {
                return NotFound();
            }
            var resultDTO = _mapper.Map<Models.DTO.User>(result);
            

            return Ok(resultDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(Models.DTO.AddUserRequest addnew)
        {
            //request(DTO) to domain model
            var user = new Models.Domain.User()
            {
                FirstName = addnew.FirstName,
                LastName = addnew.LastName,
                Email = addnew.Email,

            };


            //pass data to repository

            user=await _user.AddUser(user);


            //convert back to DTO

            var userDTO=new Models.Domain.User
            {
                UserID=user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            };

            return CreatedAtAction(nameof(GetUser), new { id = userDTO.UserID }, userDTO);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            //get user from database
            var user = await _user.DeleteUser(id);
            
            if(user==null)
            {
                return NotFound();
            }

            //convert back to DTO
            var userDTO = new Models.DTO.User
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
            return Ok(userDTO);
        }
        [HttpPut]
      public async Task<IActionResult> PutUser([FromRoute]int id, [FromBody] Models.DTO.AddUserRequest update)
        {
            //convert DTO to domain model
            var user = new Models.Domain.User()
            {
                FirstName = update.FirstName,
                LastName = update.LastName,
                Email = update.Email,

            };
            //update repository
            var result = await _user.PutUser(id, user);
            
            if(result==null)
            {
                return NotFound();
            }
            //convert domain back to DTO
            var userDTO = new Models.DTO.User
            {
                UserID=result.UserID,
                FirstName=result.FirstName,
                LastName=result.LastName,
                Email=result.Email,
            };

            return Ok(userDTO);

        }
    }
}

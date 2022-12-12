using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Entities;

namespace MoviesApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<UserDTO>>> Get(int id)
        {
            var users = await context.User.ToListAsync();
            var user_1 = new List<user>();

            foreach (var user_2 in users)
            {
                if (user_2.id == id)
                {
                    user_1.Add(user_2);
                }
            }
            return mapper.Map<List<UserDTO>>(user_1);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreationDTO userCreationDTO)
        {
            var user = mapper.Map<user>(userCreationDTO);
            var users = await context.User.ToListAsync();
            var users1 = new user();
            

            foreach (var user2 in users)
            {
                if (user2.email.Equals(user.email) && user2.password.Equals(user.password))
                {
                  user2.group = user.group;
                    user2.phone_number = user.phone_number;
                    user2.type = user.type;


                }
            }
            context.Add(user);
            await context.SaveChangesAsync();
            return NoContent();
        }


        }
}

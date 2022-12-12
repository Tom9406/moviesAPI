using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MoviesApi.Dto;
using MoviesApi.Entities;

namespace MoviesApi.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LoginController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<UserDTO>>> Get([FromBody] LoginCreationDTO loginCreationDTO)
        {
            var login = mapper.Map<login>(loginCreationDTO);
            var users = await context.User.ToListAsync();
            var user_1 = new List<user>();

            foreach (var user_2 in users)
            {
                if (user_2.email.Equals(login.email) && user_2.password.Equals(login.password)) 
                {
                    user_1.Add(user_2);
                    break;
                }
                
            }
            return mapper.Map<List<UserDTO>>(user_1);
        }
    }
}

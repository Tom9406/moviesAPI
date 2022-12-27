using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Entities;
using MoviesApi.Helpers;

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


        [HttpGet("students")]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] paginationDTO paginationDTO)
        {
           
            var user_1 = new List<user>();
            var queryable = context.User.AsQueryable();
            await HttpContext.InsetParametersPaginationInHeader(queryable);
            var users = await queryable.OrderBy(x => x.full_name).Paginate(paginationDTO).ToListAsync();

            foreach (var user_2 in users)
            {
                if (user_2.type == "Estudiante")
                {
                    user_1.Add(user_2);
                }
            }
            return mapper.Map<List<UserDTO>>(user_1);
        }

        [HttpPost("teacher")]
        public async Task<ActionResult> Post_teacher([FromBody] UserCreationDTO userCreationDTO)
        {
            var user = mapper.Map<user>(userCreationDTO);

            /*aqui  se debe retoranr error en caso de existir arrreglar esto*/

            var users = await context.User.ToListAsync();
            var users1 = new user();
            

            foreach (var user2 in users)
            {
                if (user2.email.Equals(user.email))
                {
                    /*ver como retornar el error que va qui es el caso que el email exista enotnces se debe retornar un eroor email already exist*/
                    break;
                }
            }
            /* if (/*aqui va la condicon de si exiaste error*//*) { return /*error*///; }
                                                                                    // else {
            context.Add(user);
            await context.SaveChangesAsync();
            return NoContent();
            // }
        }

        [HttpPost("student")]
        public async Task<ActionResult> Post_student([FromBody] UserCreationDTO userCreationDTO)
        {
            var user = mapper.Map<user>(userCreationDTO);
           
           

            /*aqui  se debe retoranr error en caso de existir arrreglar esto*/

            
                       
            var users = await context.User.ToListAsync();
            var users1 = new user();


            foreach (var user2 in users)
            {
                if (user2.email.Equals(user.email))
                {
                    /*ver como retornar el error que va qui es el caso que el email exista enotnces se debe retornar un eroor email already exist*/

                    break;
                }
            }

           /* if (/*aqui va la condicon de si exiaste error*//*) { return /*error*///; }
           // else { 
            context.Add(user);
            await context.SaveChangesAsync();
            return NoContent();
           
        }

        [HttpPut("student")]
        public async Task<ActionResult> Put_student(int id, [FromBody] UserCreationDTO userCreationDTO)
        {
            var user = mapper.Map<user>(userCreationDTO);
            user.id = id;
            context.Entry(id).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("teacher")]
        public async Task<ActionResult> Put_teacher(int id, [FromBody] UserCreationDTO userCreationDTO)
        {
            var user = mapper.Map<user>(userCreationDTO);
            user.id = id;
            context.Entry(id).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }




    }
}

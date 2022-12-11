using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MoviesApi.Dto;
using MoviesApi.Entities;
using System.Security.Claims;
using System.Text;

namespace MoviesApi.Controllers
{

    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context, IMapper mapper)
        {

            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        // [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]

        public async Task<ActionResult<List<GenresDto>>> GetGenres()
        {
            logger.LogInformation("Getting all genres");
            var genres = await context.Genres.ToListAsync();
            return mapper.Map<List<GenresDto>>(genres);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenresDto>> GetGenre(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            return mapper.Map<GenresDto>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenresCreationDto genrecreationDto)
        {
            var genre = mapper.Map<Genre>(genrecreationDto);
            context.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenresCreationDto genresCreationDto)
        {
            var genre = mapper.Map<Genre>(genresCreationDto);
            genre.Id = id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null) { return NotFound(); }
            context.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

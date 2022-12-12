using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Entities;

namespace MoviesApi.Controllers
{
    [Route("score")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ScoreController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ScoreDTO>>> Get(int id)
        {
            var scores = await context.Score.ToListAsync();
            var scores1 = new List<Score>();
            foreach (var score in scores)
            {
                if (score.id_exam == id)
                {
                    scores1.Add(score);
                }
            }
            return mapper.Map<List<ScoreDTO>>(scores1);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<ScoreCreationDTO> scoreCreationDTO)
        {
            var scores = mapper.Map<List<Score>>(scoreCreationDTO);
            foreach(var score in scores) { context.Add(score); }            
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}

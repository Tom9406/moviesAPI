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
        public async Task<ActionResult<List<examDTO>>> Get(int id)
        {
            var exams = await context.Subjects.ToListAsync();
            var score = new Score();
            var exam1 = new List<exam>();

            foreach (var exam in exams)
            {
                if (score.id_subject == id)
                {
                    exam1.Add(exam);
                }
            }
            return mapper.Map<List<examDTO>>(exam1);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ScoreCreationDTO scoreCreationDTO)
        {
            var score = mapper.Map<Score>(scoreCreationDTO);
            context.Add(score);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}

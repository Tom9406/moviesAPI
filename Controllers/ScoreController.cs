using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    }
}

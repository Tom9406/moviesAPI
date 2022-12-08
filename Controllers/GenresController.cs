using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Entities;


namespace MoviesApi.Controllers
{

    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;

        public GenresController( ILogger<GenresController> logger) { 
            
            this.logger = logger;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            logger.LogInformation("Getting all genres");
            return new List<Genre>() { new Genre() {Id=1, Name="Comdey" } };
        }

        [HttpGet("{Id:int}")]
        public ActionResult<Genre> GetGenre(int id)
        {
            throw new NotImplementedException();    
        }

        [HttpPost]
        public ActionResult Post([FromBody]  Genre genre)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {

            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            throw new NotImplementedException();
        }
    }
}

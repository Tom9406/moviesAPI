using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Entities;

namespace MoviesApi.Controllers
{
    [Route("exam")]
    [ApiController]
    public class examController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        
        public examController (ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<examDTO>>> Get(int id)
        {
            var asignatura = await context.Subjects.ToListAsync();
            var asignatura_1 = new List<exam>();

            foreach (var subject in asignatura)
            {
                if (subject.id_student == id)
                {
                    asignatura_1.Add(subject);
                }
            }
            return mapper.Map<List<examDTO>>(asignatura_1);
        }

        [HttpGet("test")]
        public async Task<ActionResult<List<examDTO>>> Get()
        {

            var asignatura = await context.Subjects.ToListAsync();
            var asignatura_1 = new List<exam>();

            foreach (var subject in asignatura)
            {
                if (subject.type == "examen")
                {
                    asignatura_1.Add(subject);

                }

            }
            return mapper.Map<List<examDTO>>(asignatura_1);

        }
        
        
        [HttpGet("test/checked")]
        public async Task<ActionResult<List<examDTO>>> Get_checked()
        {

            var asignatura = await context.Subjects.ToListAsync();
            var asignatura_1 = new List<exam>();

            foreach (var subject in asignatura)
            {
                if (subject.status == false)
                {
                    asignatura_1.Add(subject);

                }

            }
            return mapper.Map<List<examDTO>>(asignatura_1);

        }

        [HttpGet("test/unchecked")]
        public async Task<ActionResult<List<examDTO>>> Get_unchecked()
        {

            var asignatura = await context.Subjects.ToListAsync();
            var asignatura_1 = new List<exam>();

            foreach (var subject in asignatura)
            {
                if (subject.status == true)
                {
                    asignatura_1.Add(subject);

                }

            }
            return mapper.Map<List<examDTO>>(asignatura_1);

        }


        [HttpGet("test/unchecked/{id:int}")]
        public async Task<ActionResult<List<examDTO>>> Get_unchecked_id(int id)
        {

            var asignatura = await context.Subjects.ToListAsync();
            var asignatura_1 = new List<exam>();

            foreach (var subject in asignatura)
            {
                if (subject.status == true && subject.id_student==id)
                {
                    asignatura_1.Add(subject);

                }

            }
            return mapper.Map<List<examDTO>>(asignatura_1);

        }

        [HttpGet("test/checked/{id:int}")]
        public async Task<ActionResult<List<examDTO>>> Get_checked_id(int id)
        {

            var asignatura = await context.Subjects.ToListAsync();
            var asignatura_1 = new List<exam>();

            foreach (var subject in asignatura)
            {
                if (subject.status == false && subject.id_student == id)
                {
                    asignatura_1.Add(subject);

                }

            }
            return mapper.Map<List<examDTO>>(asignatura_1);

        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] examCreationDTO subjectCreationDTO)
        {
            var subject = mapper.Map<exam>(subjectCreationDTO);
            var asignatura = await context.Subjects.ToListAsync();
            var subject1 = new List<exam>();
            var count = 1;    
            var temp= new exam();

            foreach (var asignatura1 in asignatura)
            {
                if (asignatura1.id_student.Equals(subject.id_student) && asignatura1.name.Equals(subject.name))
                {
                    count++;
                    subject1.Add(asignatura1);
                    
                }
            }
           
            subject.intents_number = count;
            context.Add(subject);
             

            await context.SaveChangesAsync();
            temp.id = subject.id;
            return temp.id;
        }
        /*
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] asignaturaCreationDTO asignaturaCreationDTO)
        {
            
            var subject = mapper.Map<asignatura>(asignaturaCreationDTO);
            subject=  await context.asignatura.FirstOrDefaultAsync(x => x.id == id);
            asignaturaCreationDTO.intents_number = subject.intents_number;
            subject.score = asignaturaCreationDTO.score;
            subject.intents_number = asignaturaCreationDTO.intents_number + 1;
            context.Entry(subject).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
*/
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var subject = await context.Subjects.FirstOrDefaultAsync(x => x.id == id);
            if (subject == null) { return NotFound(); }
            context.Remove(subject);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}


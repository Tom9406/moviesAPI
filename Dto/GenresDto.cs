using MoviesApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class GenresDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

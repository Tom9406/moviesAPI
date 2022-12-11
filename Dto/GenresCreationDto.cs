using MoviesApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class GenresCreationDto
    {
        //Validacones para el campo que se encuentra abajo en este eejmoplo se usan 2
        [Required(ErrorMessage = "The fiel with name {0} is required")]
        [StringLength(50)]
        [FirstetteruppeCase]
        public string Name { get; set; }
    }
}

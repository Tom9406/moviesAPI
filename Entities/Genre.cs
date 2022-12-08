using MoviesApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        //Validacones para el campo que se encuentra abajo en este eejmoplo se usan 2
        [Required(ErrorMessage ="The fiel with name {0} is required")]
        [StringLength(50)]
        [FirstetteruppeCase]
        public string Name { get; set; }
    }
}

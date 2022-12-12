using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class LoginDTO
    {

        [Key]
        public int id { get; set; }

        [EmailAddress(ErrorMessage = "Wrong email format")]
        public string email { get; set; }
        public string password { get; set; }
    }
}

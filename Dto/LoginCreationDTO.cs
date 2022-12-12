using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class LoginCreationDTO
    {
        [EmailAddress(ErrorMessage = "Wrong email format")]
        public string email { get; set; }
        public string password { get; set; }
    }
}

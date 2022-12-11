using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class LoginCreationDTO
    {

        public string email { get; set; }
        public string password { get; set; }
    }
}

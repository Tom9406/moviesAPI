using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class UserCreationDTO
    {
        public string full_name { get; set; }
        public int phone_number { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}

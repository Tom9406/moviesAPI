
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class UserDTO
    {
        [Key]
        public int id { get; set; }
        public string full_name { get; set; }
        public int phone_number { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string group { get; set; }
    }
}

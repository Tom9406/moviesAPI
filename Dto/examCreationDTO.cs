using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class examCreationDTO
    {
        public int id_student { get; set; }
        public string name { get; set; }

        [Range(0, 100)]
        public int score { get; set; }
        public string type { get; set; }
        public int intents_number { get; set; } = 1;
        public bool status { get; set; }
    }
}

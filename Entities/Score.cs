using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Score
    {
        [Key]
        public int id { get; set; }
        public int id_subject { get; set; }
        public int answer { get; set; }
        public int question_number { get; set; }
        public string full_name_responsable { get; set; }
        public string justify { get; set; }
    }
}

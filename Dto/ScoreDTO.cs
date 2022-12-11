using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class ScoreDTO
    {
        [Key]
        public int id { get; set; }
        public int id_exam { get; set; } = 0;
        public int answer { get; set; } = 0;
        public int question_number { get; set; } = 0;
        public string full_name_responsable { get; set; } = string.Empty;
        public string justify { get; set; } = string.Empty;
    }
}

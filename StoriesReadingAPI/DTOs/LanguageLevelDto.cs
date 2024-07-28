using StoriesReadingAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.DTOs
{
    public class LanguageLevelDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int power { get; set; }
    }
}

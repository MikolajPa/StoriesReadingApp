using StoriesReadingAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.DTOs
{
    public class LanguageLevelRequest
    {
        public string Name { get; set; }
    }

    public class LanguageLevelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
    }
}

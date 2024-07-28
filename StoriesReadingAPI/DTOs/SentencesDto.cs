using StoriesReadingAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.DTOs
{
    public class SentenceDto
    {
        public int id { get; set; }
        public string languageOriginal { get; set; }
        public string languageTranslation { get; set; }
    }
}

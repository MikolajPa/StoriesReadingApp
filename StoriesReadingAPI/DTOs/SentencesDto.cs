using StoriesReadingAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.DTOs
{
    public class SentenceDto
    {
        public int Id { get; set; }
        public string LanguageOriginal { get; set; }
        public string LanguageTranslation { get; set; }
    }
}

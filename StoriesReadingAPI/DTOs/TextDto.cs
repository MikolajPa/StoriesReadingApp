using StoriesReadingAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.DTOs
{
    public class TextResponseDto
    {
        public int Id { get; set; }
        public string TextTitle { get; set; }
    }

    public class TextRequestDto
    {
        public string TextTitle { get; set; }
        public string TextOriginal { get; set; }
        public string TextTranslation { get; set; }
        public int LanguageOriginalId { get; set; }
        public int LanguageTranslationId { get; set; }
        public int LanguageLevelId { get; set; }
    }
}

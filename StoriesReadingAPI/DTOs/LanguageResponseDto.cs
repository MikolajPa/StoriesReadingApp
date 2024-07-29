using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.DTOs
{
    public class LanguageRequestDto
    {
        public string Name { get; set; }
    }

    public class LanguageResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

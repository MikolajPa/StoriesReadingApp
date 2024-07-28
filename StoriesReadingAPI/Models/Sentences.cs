using StoriesReadingAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.Models
{
    public class Sentences : IBase
    {
        [Key]
        public int Id { get; set; }
        public Texts Text { get; set; }
        public int Order { get; set; }
        public string LanguageOriginal { get; set; }
        public string LanguageTranslation { get; set; }
    }
}

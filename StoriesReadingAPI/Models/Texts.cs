using StoriesReadingAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoriesReadingAPI.Models
{
    public class Texts : IBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TextTitle { get; set; }

        [ForeignKey(nameof(LanguageOriginal))]
        public int LanguageOriginalId { get; set; }
        public Languages LanguageOriginal { get; set; }

        [ForeignKey(nameof(LanguageTranslation))]
        public int LanguageTranslationId { get; set; }
        public Languages LanguageTranslation { get; set; }

        [ForeignKey(nameof(LanguageLevels))]
        public int LanguageLevelsId { get; set; }
        public LanguageLevels LanguageLevels { get; set; }
    }
}

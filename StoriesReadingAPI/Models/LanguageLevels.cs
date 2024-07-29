using StoriesReadingAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoriesReadingAPI.Models
{
    public class LanguageLevels : IBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }

        [ForeignKey(nameof(Language))]
        public int LanguageId { get; set; }
        public Languages Language { get; set; }
    }
}

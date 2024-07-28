using StoriesReadingAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.Models
{
    public class LanguageLevels : IBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public Languages Language { get; set; }
    }
}

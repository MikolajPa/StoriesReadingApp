using StoriesReadingAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.Models
{
    public class Languages : IBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsShown { get; set; }
        public ICollection<LanguageLevels> Levels { get; set; }
    }
}

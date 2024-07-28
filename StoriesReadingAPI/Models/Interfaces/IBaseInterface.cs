using System.ComponentModel.DataAnnotations;

namespace StoriesReadingAPI.Models.Interfaces
{
    public interface IBase
    {
        [Key]
        public int Id { get; }
    }
}

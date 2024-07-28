using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.ServiceModels;

namespace StoriesReadingAPI.Services.Interfaces
{
    public interface ILanguageLevelService
    {
        IEnumerable<LanguageLevels> GetLanguageLevels(int intLanguageId);
    }
}

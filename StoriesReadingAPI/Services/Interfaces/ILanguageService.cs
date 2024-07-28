using StoriesReadingAPI.Models;
using StoriesReadingAPI.Repositories;

namespace StoriesReadingAPI.Services.Interfaces
{
    public interface ILanguageService
    {
        List<Languages> GetLanguageOrigin();
        List<Languages> GetLanguageTranslation(int originLanguageId);
    }
}

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.Models;

namespace StoriesReadingAPI.Repositories
{
    public interface ITextsRepository
    {
        IEnumerable<int> GetTranslationIds(int languageId);

        IEnumerable<Texts> GetTextsTitles(int originLanguageId, int translationLanguageId, int LanguageLevelId);

        IEnumerable<int> GetOriginIds(int languageId);
    }
}

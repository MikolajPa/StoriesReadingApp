using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.Models;

namespace StoriesReadingAPI.Repositories
{
    public interface ILanguageLevelsRepository
    {
        IEnumerable<LanguageLevels> GetLanguageLevels(int intLanguageId);
    }
}

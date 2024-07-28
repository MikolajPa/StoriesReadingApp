using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.Models;

namespace StoriesReadingAPI.Repositories
{
    public interface ILanguageRepository
    {
        IEnumerable<Languages> GetLanguagesOrigin();

        IEnumerable<Languages> GetLanguagesByIds(List<int> Ids);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Models.Contexts;

namespace StoriesReadingAPI.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly SampleDBContext context;

        public LanguageRepository(SampleDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Languages> GetLanguagesByIds(List<int> Ids)
        {
            var languages = context.Languages
                       .Where(l => Ids.Contains(l.Id))
                       .ToList();
            return languages;
        }

        public IEnumerable<Languages> GetLanguagesOrigin()
        {
            var allLanguages = context.Languages.Where(x=>x.IsShown == true).ToList();
            return allLanguages;
        }
    }
}

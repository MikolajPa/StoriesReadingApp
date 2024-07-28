using StoriesReadingAPI.Models;

namespace StoriesReadingAPI.Repositories
{
    public class LanguageLevelRepository : ILanguageLevelsRepository
    {
        private readonly SampleDBContext context;

        public LanguageLevelRepository(SampleDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<LanguageLevels> GetLanguageLevels(int intLanguageId)
        {
            var allLanguages = context.LanguageLevels.Where(x => x.Language.Id == intLanguageId).ToList();
            return allLanguages;
        }
    }
}

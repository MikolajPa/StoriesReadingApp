using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Models.Contexts;

namespace StoriesReadingAPI.Repositories
{
    public class TextsRepository : ITextsRepository
    {
        private readonly SampleDBContext context;

        public TextsRepository(SampleDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Texts> GetTextsTitles(int originLanguageId, int translationLanguageId, int LanguageLevelId)
        {
            var allTextsTitles = context.Texts.Where(x => x.LanguageOriginal.Id == originLanguageId && x.LanguageTranslation.Id == translationLanguageId && x.LanguageLevels.Id == LanguageLevelId).ToList();
            return allTextsTitles;
        }

        public IEnumerable<int> GetTranslationIds(int languageId)
        {
            var allTranslationsIds = context.Texts.Where(x => x.LanguageOriginal.Id == languageId).Select(c=>c.LanguageTranslation.Id).Distinct().ToList();
            return allTranslationsIds;
        }

        public IEnumerable<int> GetOriginIds(int languageId)
        {
            var allTranslationsIds = context.Texts.Select(x => x.LanguageOriginal.Id).Distinct().ToList();
            return allTranslationsIds;
        }
    }
}

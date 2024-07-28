using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.Interfaces;

namespace StoriesReadingAPI.Services
{
    public class LanguageLevelService : ILanguageLevelService
    {
        private IRepositoryBase<LanguageLevels> _languageLevelRepository;

        public LanguageLevelService(IRepositoryBase<LanguageLevels> languageLevelRepository)
        {
            _languageLevelRepository = languageLevelRepository;
        }

        public IEnumerable<LanguageLevels> GetLanguageLevels(int intLanguageId)
        {
            var allLanguages = _languageLevelRepository.GetList(x=>x.Language.Id == intLanguageId);
            return allLanguages.ToList();
        }
    }
}

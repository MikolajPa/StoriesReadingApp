using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.ServiceModels;

namespace StoriesReadingAPI.Services.Interfaces
{
    public interface IAdminService
    {
        void PostText(TextAdminServiceModel textAdminServiceModel);

        void PostLanguage(Languages language);

        IEnumerable<Languages> GetLanguages();

        void PostLanguageLevel(LanguageLevels language);

        void PostLanguageLevels(List<LanguageLevels> language, int languageLevelId);

        IEnumerable<LanguageLevels> GetLanguageLevels(int languageId);

        void DeleteLanguageLevel(int languageLevelId);

        void DeleteLanguage(int languageId);
    }
}

using StoriesReadingAPI.Models;
using StoriesReadingAPI.Repositories;
using StoriesReadingAPI.Services.Interfaces;
using StoriesReadingAPI.Services.ServiceHelpers;
using StoriesReadingAPI.Services.ServiceModels;

namespace StoriesReadingAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly IRepositoryBase<Languages> _languageRepository;
        private readonly IRepositoryBase<Texts> _textsRepository;
        private readonly IRepositoryBase<LanguageLevels> _languageLevelRepository;
        private readonly IRepositoryBase<Sentences> _sentenceRepository;

        public AdminService(IRepositoryBase<Languages> languageRepository, IRepositoryBase<Texts> textsRepository, IRepositoryBase<LanguageLevels> languageLevelRepository, IRepositoryBase<Sentences> sentenceRepository)
        {
            _languageLevelRepository = languageLevelRepository;
            _textsRepository = textsRepository;
            _languageRepository = languageRepository;
            _sentenceRepository = sentenceRepository;
        }

        public void DeleteLanguage(int languageId)
        {
            var language = _languageRepository.GetId(languageId);
            if (language != null)
            {
                _languageRepository.Remove(language);
            }
        }

        public void DeleteLanguageLevel(int languageLevelId)
        {
            var languageLevel = _languageLevelRepository.GetId(languageLevelId);
            if(languageLevel != null)
            {
                _languageLevelRepository.Remove(languageLevel);
            }
        }

        public IEnumerable<LanguageLevels> GetLanguageLevels(int languageId)
        {
            return _languageLevelRepository.GetList(x => x.Language.Id == languageId);
        }

        public IEnumerable<Languages> GetLanguages()
        {
            return _languageRepository.GetAll().ToList();
        }

        public void PostLanguage(Languages language)
        {
            _languageRepository.Add(language);
        }

        public void PostLanguageLevel(LanguageLevels language)
        {
            _languageLevelRepository.Add(language);
        }

        public void PostText(TextAdminServiceModel textAdminServiceModel)
        {

            var texts = new Texts
            {
                TextTitle = textAdminServiceModel.TextTitle,
                LanguageOriginalId = textAdminServiceModel.LanguageOriginalId,
                LanguageTranslationId = textAdminServiceModel.LanguageTranslationId,
                LanguageLevelsId = textAdminServiceModel.LanguageLevelId
            };

            texts = _textsRepository.AddNoSave(texts);
            var originalTextProcessed = TextProcessor.ProcessText(textAdminServiceModel.TextOriginal);
            var translatedTextProcessed = TextProcessor.ProcessText(textAdminServiceModel.TextTranslation);

            var sentences = originalTextProcessed.Select((sentence, index) => new Sentences
            {
                LanguageTranslation = translatedTextProcessed[index],
                LanguageOriginal = sentence,
                Order = index,
                Text = texts
            }).ToList();

            _sentenceRepository.AddRange(sentences);
        }
    }
}

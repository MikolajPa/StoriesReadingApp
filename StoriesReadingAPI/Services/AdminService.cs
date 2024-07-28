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

using Microsoft.EntityFrameworkCore;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Models.Contexts;
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
        private readonly SampleDBContext _context;

        public AdminService(IRepositoryBase<Languages> languageRepository, IRepositoryBase<Texts> textsRepository, IRepositoryBase<LanguageLevels> languageLevelRepository, IRepositoryBase<Sentences> sentenceRepository, SampleDBContext context)
        {
            _languageLevelRepository = languageLevelRepository;
            _textsRepository = textsRepository;
            _languageRepository = languageRepository;
            _sentenceRepository = sentenceRepository;
            _context = context;
        }

        public void DeleteLanguage(int languageId)
        {
            var language = _languageRepository.GetId(languageId);
            if (language != null)
            {
                _languageRepository.Remove(language);
            }
            else
            {
                throw new ArgumentException("Language not found");
            }
        }

        public void DeleteLanguageLevel(int languageLevelId)
        {
            var languageLevel = _languageLevelRepository.GetId(languageLevelId);
            if(languageLevel != null)
            {
                _languageLevelRepository.Remove(languageLevel);
            }
            else
            {
                throw new ArgumentException("Language level not found");
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

        public void PostLanguageLevels(List<LanguageLevels> languageLevels, int languagId) //Zrobic optymalnie walidacje czy kazdy z podanych jezykow nie ma wartosci Name null i dodac customowy error
        {
            var namesFromList = new HashSet<string>(languageLevels.Select(level => level.Name));
            var existingLanguageLevels = _languageLevelRepository.GetList(x => x.LanguageId == languagId);
            var existingLevelsDictionary = existingLanguageLevels.ToDictionary(x => x.Name);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < languageLevels.Count; i++)
                    {
                        var level = languageLevels[i];
                        level.Power = i;
                        level.LanguageId = languagId;

                        if (existingLevelsDictionary.TryGetValue(level.Name, out var existingLanguageLevel))
                        {
                            existingLanguageLevel.Power = i;
                            _languageLevelRepository.Update(existingLanguageLevel);
                        }
                        else
                        {
                            _languageLevelRepository.Add(level);
                        }
                    }

                    var namesInDatabase = new HashSet<string>(existingLevelsDictionary.Keys);
                    var namesToRemove = namesInDatabase.Except(namesFromList).ToList();

                    foreach (var nameToRemove in namesToRemove)
                    {
                        var levelsToRemove = existingLanguageLevels.Where(x => x.Name == nameToRemove).ToList();
                        foreach (var levelToRemove in levelsToRemove)
                        {
                            try
                            { 
                                _languageLevelRepository.Remove(levelToRemove);
                            }
                            catch(Exception ex)
                            {
                                throw new Exception("Object has stories in it"); //Dodac customowe errory i wyrzucac go typu "LanguageContainsStoriesException"
                            }
                        }
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex) //catch dla kazdego erroru osobno
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
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

        private HashSet<string> GetNamesFromList(List<LanguageLevels> languageLevels)
        {
            return new HashSet<string>(languageLevels.Select(level => level.Name));
        }
    }
}

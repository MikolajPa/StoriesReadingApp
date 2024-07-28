using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Repositories;
using StoriesReadingAPI.Services.Interfaces;

namespace StoriesReadingAPI.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageRepository _repository;
        private readonly ITextsRepository _textsRepository;

        public LanguageService(ILanguageRepository repository, ITextsRepository textsRepository, ILogger<LanguageController> logger)
        {
            _logger = logger;
            _repository = repository;
            _textsRepository = textsRepository;
        }

        public List<Languages> GetLanguageOrigin()
        {
            var languages = _repository.GetLanguagesOrigin();
            _logger.LogDebug($"Get method called, got {languages.Count()} results");
            return languages.ToList();
        }

        public List<Languages> GetLanguageTranslation(int originLanguageId)
        {
            var languagesIds = _textsRepository.GetTranslationIds(originLanguageId);
            var languages = _repository.GetLanguagesByIds(languagesIds.ToList());
            _logger.LogDebug($"Get method called, got {languages.Count()} results");
            return languages.ToList();
        }
    }
}

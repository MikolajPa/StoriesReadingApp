using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.Interfaces;

namespace StoriesReadingAPI.Repositories
{
    public class SentenceService : ISentenceService
    {
        private IRepositoryBase<Sentences> _sentencesRepository;

        public SentenceService(IRepositoryBase<Sentences> sentencesRepository)
        {
            _sentencesRepository = sentencesRepository;
        }

        public IEnumerable<Sentences> GetSentences(int textId)
        {
            var allSentences = _sentencesRepository.GetList(x=>x.Text.Id == textId).OrderBy(s => s.Order).ToList();
            return allSentences;
        }
    }
}

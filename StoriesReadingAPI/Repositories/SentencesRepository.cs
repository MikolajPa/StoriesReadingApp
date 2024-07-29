using StoriesReadingAPI.Models;
using StoriesReadingAPI.Models.Contexts;

namespace StoriesReadingAPI.Repositories
{
    public class SentencesRepository : ISentencesRepository
    {
        private readonly SampleDBContext context;

        public SentencesRepository(SampleDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Sentences> GetSentences(int textId)
        {
            var allSentences = context.Sentences.Where(x => x.Text.Id == textId).OrderBy(s=>s.Order).ToList();
            return allSentences;
        }
    }
}

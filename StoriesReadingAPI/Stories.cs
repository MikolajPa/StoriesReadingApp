using StoriesReadingAPI.Services.ServiceHelpers;

namespace StoriesReadingAPI
{
    public class Story
    {
        public Story(string title, string originText, string translationText, LevelEnglish levelEnglish, LanguageOrigin originLanguage, LanguageTranslation translationLanguage) 
        {
            Title = title;
            LevelEnglish = levelEnglish;
            OriginLanguage = originLanguage;
            TranslationLanguage = translationLanguage;
            List<string> translatedSentences = TextProcessor.ProcessText(translationText);
            Sentances = new List<Sentance>();
            List<string> originSentences = TextProcessor.ProcessText(originText);

            if(originSentences.Count == translatedSentences.Count)
            {
                for(int i = 0; i < originSentences.Count; i++)
                {
                    Sentances.Add(new Sentance(originSentences[i], translatedSentences[i]));
                }
            }
        
        }
        public string Title { get; set; }

        public List<Sentance> Sentances { get; set; }

        public LevelEnglish LevelEnglish { get; set; }

        public LanguageOrigin OriginLanguage { get; set; }

        public LanguageTranslation TranslationLanguage { get; set; }
    }

    public class Sentance
    {
        public Sentance(string sentenceOrigin, string sentenceTranslated)
        {
            SentenceOrigin = sentenceOrigin;
            SentenceTranslated = sentenceTranslated;
        }
        public string SentenceOrigin { get; set; }
        public string SentenceTranslated { get; set; }
    }
    public class Stories
    {
        public List<Story> AllStories { get; set; } = new List<Story>();
        public void AddStory(string title, string textOrigin, string textTranslate, LevelEnglish levelEnglish, LanguageOrigin origin, LanguageTranslation translationLanguage)
        {
            AllStories.Add(new Story(title, textOrigin, textTranslate, levelEnglish, origin, translationLanguage));
        }
    }

    public static class AddStories
    {
        public static Stories Load()
        {
            Stories stories = new Stories();
            stories = AddStoryCatEnglish(stories);
            return stories;

        }
        public static Stories AddStoryCatEnglish(Stories stories)
        {
            string title = "The Hungry Cat";
            string textOriginal = "A cat is very hungry. She sees a mouse. The mouse is small. The cat catches the mouse. The cat eats the mouse. Now, the cat is happy.";
            string textTranslation = "Kot jest bardzo głodny. Widzi mysz. Mysz jest mała. Kot łapie mysz. Kot zjada mysz. Teraz kot jest szczęśliwy.";
            stories.AddStory(title, textOriginal, textTranslation, LevelEnglish.A1, LanguageOrigin.English, LanguageTranslation.Polish);
            return stories;
        }
    }

    public enum LevelEnglish
    {
        A1,
        A2,
        B1,
        B2
    }

    public enum LanguageOrigin
    {
        English
    }

    public enum LanguageTranslation
    {
        Polish
    }

}

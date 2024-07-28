namespace StoriesReadingAPI.Services.ServiceHelpers
{
    public static class TextProcessor
    {
        public static List<string> ProcessText(string text)
        {
            List<string> Sentences = new List<string>();
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Input text cannot be null or whitespace.", nameof(text));
            }

            char[] sentenceEndings = { '.', '!', '?' };
            int startIndex = 0;

            while (startIndex < text.Length)
            {
                int endIndex = text.IndexOfAny(sentenceEndings, startIndex);

                if (endIndex == -1)
                {
                    string lastSentence = text.Substring(startIndex).Trim();
                    if (!string.IsNullOrEmpty(lastSentence))
                    {
                        Sentences.Add(lastSentence);
                    }
                    break;
                }
                endIndex++;
                string sentence = text.Substring(startIndex, endIndex - startIndex).Trim();
                if (!string.IsNullOrEmpty(sentence))
                {
                    Sentences.Add(sentence);
                }

                startIndex = endIndex;
            }

            return Sentences;
        }
    }
}

using System;

namespace TechTest
{
    /// <summary>
    /// Extracts statistics from the supplied string.
    /// </summary>
    public class StringStatsProcessor
    {
        /// <summary>
        /// Extracts statistics from the supplied string.
        /// </summary>
        /// <param name="subject">Must not be null.</param>
        /// <returns>A model containing statistics for the supplied string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the supplied input is null.</exception>
        public StringStatsModel Run(string subject)
        {
            StringStatsModel stringStats = new StringStatsModel();
            stringStats.NumberOfCharacters = subject.Length;
            stringStats.NumberOfWords = GetNumberOfWords(subject);
            stringStats.LongestWordNumberOfCharacters = GetLongestWordCharacterNumber(subject);

            return stringStats; 
        }


        private long GetNumberOfWords(string subject)
        {
            string[] wordSplit = subject.Split(' ');

            return wordSplit.Length;
        }

        private long GetLongestWordCharacterNumber(string subject)
        {
            string[] wordSplit = subject.Split(' ');
            long maxNumber = 0; 
            foreach(var word in wordSplit)
            {
                if(word.Length > maxNumber)
                {
                    maxNumber = word.Length;
                }
            }

            return maxNumber;
        }
    }
}
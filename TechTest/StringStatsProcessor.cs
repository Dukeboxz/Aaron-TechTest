using System;

namespace TechTest
{
    /// <summary>
    /// Extracts statistics from the supplied string.
    /// </summary>
    public class StringStatsProcessor : IStringStatProcessor
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


        /// <summary>
        /// Helper method that gets number of seperate words in string
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public long GetNumberOfWords(string subject)
        {
            if(string.Empty == subject || string.IsNullOrWhiteSpace(subject))
            {
                return 0;
            }
            string[] wordSplit = subject.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return wordSplit.Length;
        }

        /// <summary>
        /// Helper methods that returns the length of longest seperate word in string.
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public long GetLongestWordCharacterNumber(string subject)
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
using System;
using System.Text;
using Xunit;

namespace TechTest.Tests
{
    /// <summary>
    /// Unit tests for StringStatsProcessor.
    /// </summary>
    public class StringStatsProcessorTests
    {


        /// <summary>
        /// Basic test number of words
        /// </summary>
        [Fact]
        public void ReturnCorrectModelNumberWord()
        {
            var processor = new StringStatsProcessor();
            var returnedModel = processor.Run("3 word string"); 

            Assert.Equal(3, returnedModel.NumberOfWords);

        }

        /// <summary>
        /// Basic test number of characters
        /// </summary>
        [Fact]
        public void ReturnCorrectModelCharacterCount()
        {
            var processor = new StringStatsProcessor();
            var returnedModel = processor.Run("3 word string");

            Assert.Equal(13, returnedModel.NumberOfCharacters);
        }

        /// <summary>
        /// Basic test longest word length
        /// </summary>
        [Fact]
        public void ReturnCorrectModelLongestWordLength()
        {
            var processor = new StringStatsProcessor();
            var returnedModel = processor.Run("3 word string");

            Assert.Equal(6, returnedModel.LongestWordNumberOfCharacters);
        }


        /// <summary>
        /// Test with no white space word number method
        /// </summary>
        [Fact]
        public void NoSpacesNumberOfWords()
        {
            var processor = new StringStatsProcessor();
            long wordNumber = processor.GetNumberOfWords("stringWithNoSpaces"); 

            Assert.Equal((long)1, wordNumber);
        }

        /// <summary>
        /// Test with no whitespace longer word character
        /// </summary>
        [Fact]
        public void NoSpacesLongestWord()
        {
            var processor = new StringStatsProcessor();
            long characters = processor.GetLongestWordCharacterNumber("stringWithNoSpaces");

            Assert.Equal((long)18, characters);
        }

        /// <summary>
        /// Test get number of words with string with punctuation 
        /// </summary>
        [Fact]
        public void PunctationNumberOfWords()
        {
            var processor = new StringStatsProcessor();
            long words = processor.GetNumberOfWords("I'm a string with puntuation.");

            Assert.Equal((long)5, words);
        }

        /// <summary>
        /// Test longest word method on character number with punctuation string
        /// </summary>
        [Fact]
        public void PunctationCharacterLongestWord()
        {
            var processor = new StringStatsProcessor();
            long characters = processor.GetLongestWordCharacterNumber("word1 word2 word3.");

            Assert.Equal((long)6, characters);
        }

        /// <summary>
        /// Number of wrds test with empty string
        /// </summary>
        [Fact]
        public void EmptyStringNumberOfWords()
        {
            var processor = new StringStatsProcessor();
            long wordNumber = processor.GetNumberOfWords(String.Empty);

            Assert.Equal((long)0, wordNumber);
        }


        /// <summary>
        /// longest word test with empty string
        /// </summary>
        [Fact]
        public void EmptyStringLongestWord()
        {
            var processor = new StringStatsProcessor();
            long characters = processor.GetLongestWordCharacterNumber(string.Empty);

            Assert.Equal((long)0, characters);
        }

        /// <summary>
        /// number of words with whitespace string
        /// </summary>
        [Fact]
        public void WhitespaceStringNumberOfWords()
        {
            var processor = new StringStatsProcessor();
            long wordNumber = processor.GetNumberOfWords("   ");

            Assert.Equal((long)0, wordNumber);
        }

        [Fact]
        public void NumberOfWordsWhitespaceAtEnd()
        {
            var processor = new StringStatsProcessor();
            long wordNumber = processor.GetNumberOfWords("whitespace at end ");

            Assert.Equal((long)3, wordNumber);
        }

        /// <summary>
        /// longest character with whitespace string 
        /// </summary>
        [Fact]
        public void WhitespaceStringLongestWordCharacters()
        {
            var processor = new StringStatsProcessor();
            long wordNumber = processor.GetLongestWordCharacterNumber("   ");

            Assert.Equal((long)0, wordNumber);
        }

        [Fact]
        public void DealWithLargeInputNumberOfWords()
        {
            string words = "Stephen's headphone hair is awsome!";
            long totalWords = 5;
            StringBuilder strb = new StringBuilder("Stephen's headphone hair is awsome!"); 


            for(int i = 0; i < 150000; i++)
            {
                strb.Append(' ');
                strb.Append(words); 
               
                totalWords = totalWords + 5;
            }



            var processor = new StringStatsProcessor();
            var returnedModel = processor.Run(strb.ToString());

            Assert.Equal(totalWords, returnedModel.NumberOfWords);
            Assert.Equal(9, returnedModel.LongestWordNumberOfCharacters); 

        }

         

    }
}
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Morse
{
    public class MorseCodeTranslatorTests
    {
        [Fact]
        public void TranslateToMorseCode_ShouldTranslateTextToMorseCode()
        {
            // Arrange
            string sentence = "Hello World";
            string expectedMorseCode = ".... . .-.. .-.. --- | .-- --- .-. .-.. -..";

            // Act
            string actualMorseCode = MorseCodeTranslator.ToMorse(sentence);

            // Assert
            Assert.Equal(expectedMorseCode, actualMorseCode);
        }

        [Fact]
        public void TranslateFromMorseCode_ShouldTranslateMorseCodeToText()
        {
            // Arrange
            string morseCode = ".... . .-.. .-.. --- | .-- --- .-. .-.. -..";
            string expectedText = "HELLO WORLD";

            // Act
            string actualText = MorseCodeTranslator.FromMorse(morseCode);

            // Assert
            Assert.Equal(expectedText, actualText);
        }
    }
}
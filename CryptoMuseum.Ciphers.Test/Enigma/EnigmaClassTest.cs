using System;
using CryptoMuseum.Ciphers.Enigma;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class EnigmaClassTest : IDisposable
    {
        private IEnigma _enigma;
        private const string TestString = "ASDHGFLJKFDHUIGERBBVXMYJGNMRFSDHIF";

        public EnigmaClassTest()
        {
            _enigma = InitHelper.CreateCustomEnigma();
        }

        [Theory]
        [InlineData('E', 'C')]
        [InlineData('N', 'T')]
        [InlineData('I', 'R')]
        [InlineData('G', 'B')]
        [InlineData('M', 'A')]
        [InlineData('A', 'M')]
        public void PressKey(char input, char expectedOutput)
        {
            var result = _enigma.PressKey(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Reset()
        {
            var try1 = _enigma.Crypt(TestString);
            _enigma.Reset();
            var try2 = _enigma.Crypt(TestString);

            Assert.Equal(try1, try2);
        }

        [Fact]
        public void NoReset()
        {
            var try1 = _enigma.Crypt(TestString);
            var try2 = _enigma.Crypt(TestString);

            Assert.NotEqual(try1, try2);
        }

        public void Dispose()
        {
            _enigma = null;
        }
    }
}
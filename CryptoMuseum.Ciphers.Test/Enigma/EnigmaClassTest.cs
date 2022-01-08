using System;
using CryptoMuseum.Ciphers.Extensions;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class EnigmaClassTest : IDisposable
    {
        private Ciphers.Enigma.Enigma _enigma;
        private const string TestString = "ASDHGFLJKFDHUIGERBBVXMYJGNMRFSDHIF";
        
        public EnigmaClassTest()
        {
            _enigma = InitHelper.CreateEnigma();
        }

        [Theory]
        [InlineData('E','R')]
        [InlineData('N','Y')]
        [InlineData('I','E')]
        [InlineData('G','M')]
        [InlineData('M','L')]
        [InlineData('A','K')]
        [InlineData('K','A')]
        public void PressKey_MethodTest(char input, char expectedOutput)
        {
            var result = _enigma.PressKey(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Reset_MethodTest()
        {
            var try1 = _enigma.Crypt(TestString);
            _enigma.Reset();
            var try2 = _enigma.Crypt(TestString);

            Assert.Equal(try1, try2);
        }

        [Fact]
        public void NoReset_MethodTest()
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
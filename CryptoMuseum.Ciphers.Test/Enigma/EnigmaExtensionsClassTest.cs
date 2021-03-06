using System;
using CryptoMuseum.Ciphers.Enigma;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class EnigmaExtensionsClassTest : IDisposable
    {
        private IEnigma _enigma;

        public EnigmaExtensionsClassTest()
        {
            _enigma = InitHelper.CreateCustomEnigma();
        }

        [Theory]
        [InlineData("HELLOWORLD", "ZVWSTEFPPI")]
        [InlineData("ZVWSTEFPPI", "HELLOWORLD")]
        public void Crypt(string input, string expectedOutput)
        {
            var result = _enigma.Crypt(input);

            Assert.Equal(expectedOutput, result);
        }

        public void Dispose()
        {
            _enigma = null;
        }
    }
}
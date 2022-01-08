using System;
using Xunit;
using CryptoMuseum.Ciphers.Extensions;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class EnigmaExtensionsClassTest : IDisposable
    {
        private Ciphers.Enigma.Enigma _enigma;

        public EnigmaExtensionsClassTest()
        {
            _enigma = InitHelper.CreateEnigma();
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
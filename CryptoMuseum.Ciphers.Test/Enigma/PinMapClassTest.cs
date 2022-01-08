using CryptoMuseum.Ciphers.Enigma;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class PinMapClassTest
    {
        [Theory]
        [InlineData(PinMap.Letters, "JGDQOXUSCAMIFRVTPNEWKBLZYH", 0, 9)]
        [InlineData(PinMap.Letters, "JGDQOXUSCAMIFRVTPNEWKBLZYH", 23, 25)]
        [InlineData("JGDQOXUSCAMIFRVTPNEWKBLZYH", PinMap.Letters, 25, 23)]
        public void GetOutputPin_MethodTest(string input, string output, int inputPin, int expectedOutputPin)
        {
            var outputPin = PinMap.GetOutputPin(input, output, inputPin);
            Assert.Equal(expectedOutputPin, outputPin);
        }
    }
}

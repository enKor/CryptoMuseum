using CryptoMuseum.Ciphers.Enigma;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class RotorClassTest
    {
        [Fact]
        public void Reset_MethodTest()
        {
            var rotor = InitHelper.CreateRotor();
            var initPosition = rotor.GetPosition();
            rotor.Rotate();
            rotor.Reset();
            var currentPosition = rotor.GetPosition();
            Assert.Equal(initPosition, currentPosition);
        }

        [Theory]
        [InlineData(new[] { 1 }, 1, true)]
        [InlineData(new[] { 1, 7 }, 7, true)]
        [InlineData(new[] { 1, 7 }, 6, false)]
        [InlineData(new[] { 1 }, 2, false)]
        public void ShouldRotateNextRotor_MethodTest(int[] notches, int rotation, bool expectedResult)
        {
            var rotor = new Rotor("JGDQOXUSCAMIFRVTPNEWKBLZYH", notches, rotation);
            var result = rotor.ShouldRotateNextRotor();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Rotate_MethodTest()
        {
            var rotor = InitHelper.CreateRotor();
            var initPosition = rotor.GetPosition();
            rotor.Rotate();
            var currentPosition = rotor.GetPosition();
            Assert.NotEqual(initPosition, currentPosition);
        }
    }
}
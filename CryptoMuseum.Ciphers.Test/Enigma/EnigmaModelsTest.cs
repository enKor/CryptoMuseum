using CryptoMuseum.Ciphers.Enigma;
using CryptoMuseum.Ciphers.Enigma.Models;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    public class EnigmaModelsTest
    {
        private readonly string _textToEncode = "EnigmaWasBrokenByMathematiciansBritishAlanTuringAndPolishMarianRejewskiDuringWWII".ToUpper();

        [Theory]
        [InlineData(10, 9, 5, 3, 15, 22, "QWERCTYUIOPSZNJKADLFHXBVGM")]
        [InlineData(6, 2, 1, 1, 15, 2, "QWERCTYUIOPSZNJKADLFHXBVGM")]
        [InlineData(2, 23, 3, 1, 15, 16, "WBERCTYUIOPSZNJKQDLFHXAVGM")]
        public void GermanRailwayRocket(int n1, int r1, int n2, int r2, int n3, int r3, string plugboard)
        {
            var enigma = new GermanRailwayRocket(
                new PlugBoard(plugboard),
                new Rotor(Ciphers.Enigma.Models.GermanRailwayRocket.IIC, new[] { n1 }, r1),
                new Rotor(Ciphers.Enigma.Models.GermanRailwayRocket.IIIC, new[] { n2 }, r2),
                new Rotor(Ciphers.Enigma.Models.GermanRailwayRocket.IC, new[] { n3 }, r3)
            );

            Check(enigma);
        }

        [Theory]
        [InlineData(10, 10, 5, 3, 15, 22, "QWERCTYUIOPSZNJKADLFHXBVGM")]
        [InlineData(6, 2, 1, 3, 5, 26, "QWERCTYUIOPSZNJKADLFHXBVGM")]
        [InlineData(23, 2, 3, 1, 22, 16, "WBERCTYUIOPSZNJKQDLFHXAVGM")]
        public void SwissK(int n1, int r1, int n2, int r2, int n3, int r3, string plugboard)
        {
            var enigma = new SwissK(
                new PlugBoard(plugboard),
                new Rotor(Ciphers.Enigma.Models.SwissK.IK, new[] { n1 }, r1),
                new Rotor(Ciphers.Enigma.Models.SwissK.IIIK, new[] { n2 }, r2),
                new Rotor(Ciphers.Enigma.Models.SwissK.IIK, new[] { n3 }, r3)
            );

            Check(enigma);
        }

        private void Check(IEnigma enigma)
        {
            var encoded = enigma.Crypt(_textToEncode);
            enigma.Reset();
            var decoded = enigma.Crypt(encoded);

            Assert.Equal(_textToEncode, decoded);
        }
    }
}
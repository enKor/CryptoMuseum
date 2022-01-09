using CryptoMuseum.Ciphers.Vigenere;
using Xunit;

namespace CryptoMuseum.Ciphers.Test.Vigenere
{
    public class VigenereCipherClassTest
    {
        [Theory]
        [InlineData("SUPERLONGTEXT", "SHORTKEY", "KBDVKVSLYASOM")]
        [InlineData("SHORTTEXT", "TOOMUCHLONGKEY", "LVCDNVLIH")]
        [InlineData("HELLO", "WORLD", "DSCWR")]
        [InlineData("SAMEKEYANDTEXT", "SAMEKEYANDTEXT", "KAYIUIWAAGMIUM")]
        public void EncryptAndDecrypt(string decoded, string key, string encoded)
        {
            var cipher = new VigenereCipher();
            var resultEncoded = cipher.Encode(decoded, key);
            var resultDecoded = cipher.Decode(resultEncoded, key);

            Assert.Equal(encoded, resultEncoded);
            Assert.Equal(decoded, resultDecoded);
        }
    }
}
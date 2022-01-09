using System.Linq;
using System.Text;

namespace CryptoMuseum.Ciphers.Vigenere
{
    public class VigenereCipher
    {
        /// <summary>
        /// Characters set to be used
        /// </summary>
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly char[,] Map;

        public VigenereCipher()
        {
            Map = CreateMap();
        }

        public string Encode(string input, string key)
        {
            var sb = new StringBuilder(input.Length);

            for (var position = 0; position < input.Length; position++)
            {
                var letter = input[position];
                var idxOfLetterToEncrypt = Letters.IndexOf(letter);
                var idxOfKeyLetter = Letters.IndexOf(key[position % key.Length]);
                sb.Append(Map[idxOfLetterToEncrypt, idxOfKeyLetter]);
            }

            return sb.ToString();
        }

        public string Decode(string input, string key)
        {
            var sb = new StringBuilder(input.Length);

            for (var position = 0; position < input.Length; position++)
            {
                var letter = input[position];
                var idxOfKeyLetter = Letters.IndexOf(key[position % key.Length]);
                var idxOfDecryptedLetter = Enumerable
                    .Range(0, Map.GetLength(1))
                    .Single(x => Map[idxOfKeyLetter, x] == letter);
                sb.Append(Letters[idxOfDecryptedLetter]);
            }

            return sb.ToString();
        }

        private static char[,] CreateMap()
        {
            var map = new char[Letters.Length, Letters.Length];

            for (var row = 0; row < Letters.Length; row++)
            {
                for (var column = 0; column < Letters.Length; column++)
                {
                    var idx = column + row;
                    var shiftedIdx = idx < Letters.Length ? idx : idx - Letters.Length;
                    map[row, column] = Letters[shiftedIdx];
                }
            }

            return map;
        }

    }
}

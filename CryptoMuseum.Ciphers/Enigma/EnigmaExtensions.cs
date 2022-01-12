using System.Text;

namespace CryptoMuseum.Ciphers.Enigma
{
    public static class EnigmaExtensions
    {
        /// <summary>
        /// Encrypts/decrypts text on Enigma
        /// </summary>
        /// <param name="enigma">Enigma machine</param>
        /// <param name="text">Text to be encrypted/decrypted</param>
        /// <returns>encrypted/decrypted text</returns>
        public static string Crypt(this IEnigma enigma, string text)
        {
            var sb = new StringBuilder(text.Length);
            
            foreach (var c in text)
            {
                sb.Append(enigma.PressKey(c));
            }

            return sb.ToString();
        }
    }
}
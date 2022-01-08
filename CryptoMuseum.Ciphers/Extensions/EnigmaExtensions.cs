using System.Text;

namespace CryptoMuseum.Ciphers.Extensions
{
    public static class EnigmaExtensions
    {
        public static string Crypt(this Enigma.Enigma enigma, string text)
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
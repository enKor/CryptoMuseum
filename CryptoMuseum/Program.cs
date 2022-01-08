using CryptoMuseum.Ciphers.Enigma;
using CryptoMuseum.Ciphers.Extensions;

namespace CryptoMuseum
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var slowRotor = new Rotor("JGDQOXUSCAMIFRVTPNEWKBLZYH", new[] { 17 /*Q*/ }, 1);
            var midRotor = new Rotor("NTZPSFBOKMWRCJDIVLAEYUXHGQ", new [] { 5 /*E*/ }, 1);
            var fastRotor = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", new [] { 22 /*V*/ }, 1);

            var enigma = new Enigma(PlugBoard.WithNoMapping, fastRotor, midRotor, slowRotor);

            var encrypted = enigma.Crypt("HelloWorld".ToUpper());
            enigma.Reset();
            var decrypted = enigma.Crypt(encrypted.ToUpper());



        }
    }
}

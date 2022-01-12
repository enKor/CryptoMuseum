using System;
using CryptoMuseum.Ciphers.Enigma;
using CryptoMuseum.Ciphers.Vigenere;

namespace CryptoMuseum
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //RunEnigma();
            RunVigenere();
        }

        private static void RunVigenere()
        {
            var cipher = new VigenereCipher();
            const string key = "ANYKEY";
            var encrypted = cipher.Encode("VIGENERECIPHER", key);
            var decrypted = cipher.Decode(encrypted, key);
            
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
        }

        private static void RunEnigma()
        {
            var slowRotor = new Rotor("JGDQOXUSCAMIFRVTPNEWKBLZYH", new[] { 17 /*Q*/ }, 1);
            var midRotor = new Rotor("NTZPSFBOKMWRCJDIVLAEYUXHGQ", new[] { 5 /*E*/ }, 1);
            var fastRotor = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", new[] { 22 /*V*/ }, 1);

            var enigma = new Enigma(
                new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT"),
                PlugBoard.WithNoMapping, 
                fastRotor, midRotor, slowRotor);

            var encrypted = enigma.Crypt("ENIGMA");
            enigma.Reset();
            var decrypted = enigma.Crypt(encrypted);

            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
        }


    }
}

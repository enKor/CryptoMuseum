using CryptoMuseum.Ciphers.Enigma;

namespace CryptoMuseum.Ciphers.Test.Enigma
{
    internal static class InitHelper
    {
        public static IEnigma CreateCustomEnigma()
        {
            var slowRotor = new Rotor("JGDQOXUSCAMIFRVTPNEWKBLZYH", new[] { 17 /*Q*/ }, 1);
            var midRotor = new Rotor("NTZPSFBOKMWRCJDIVLAEYUXHGQ", new[] { 5 /*E*/ }, 1);
            var fastRotor = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", new[] { 22 /*V*/ }, 1);

            return new Ciphers.Enigma.Enigma(
                new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT"),
                PlugBoard.WithNoMapping, 
                fastRotor, midRotor, slowRotor);
        }

        public static Rotor CreateRotor() => new("JGDQOXUSCAMIFRVTPNEWKBLZYH", new[] {17 /*Q*/}, 1);
    }
}

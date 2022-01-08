namespace CryptoMuseum.Ciphers.Enigma
{
    internal class Reflector : StaticPinMap
    {
        public static readonly Reflector Default = new("YRUHQSLDPXNGOKMIEBFZCWVJAT");

        private Reflector(string map) : base(map)
        {

        }
    }
}
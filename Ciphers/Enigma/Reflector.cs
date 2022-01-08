namespace Ciphers.Enigma
{
    public class Reflector : StaticPinMap
    {
        public static readonly Reflector Default = new("YRUHQSLDPXNGOKMIEBFZCWVJAT");

        public Reflector(string map) : base(map)
        {

        }
    }
}
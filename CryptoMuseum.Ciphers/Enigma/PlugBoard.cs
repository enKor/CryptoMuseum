namespace CryptoMuseum.Ciphers.Enigma
{
    public class PlugBoard : StaticPinMap
    {
        public static readonly PlugBoard WithNoMapping = new(Letters);

        public PlugBoard(string map) : base(map)
        {
        }

    }
}
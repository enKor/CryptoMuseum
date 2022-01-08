namespace Ciphers.Enigma
{
    public abstract class StaticPinMap : PinMap
    {
        protected StaticPinMap(string map) : base(map)
        {

        }

        public int EncryptPin(int inputPin) => GetOutputPin(Letters, Map, inputPin);
    }
}
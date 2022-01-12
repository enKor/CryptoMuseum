namespace CryptoMuseum.Ciphers.Enigma
{
    public interface IEnigma
    {
        void Reset();
        char PressKey(char c);
    }
}
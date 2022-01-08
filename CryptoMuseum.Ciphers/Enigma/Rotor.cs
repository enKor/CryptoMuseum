using System.Linq;

namespace CryptoMuseum.Ciphers.Enigma
{
    public class Rotor : PinMap
    {
        private readonly int[] _notches;
        private int _rotation; // TODO to prop and remove GetPosition()
        private readonly int _startPosition;

        public Rotor(string map, int[] notches, int rotation) : base(map)
        {
            _notches = notches;
            _rotation = rotation;
            _startPosition = rotation;

            //TODO params checks
        }

        public void Reset() => _rotation = _startPosition;

        public bool ShouldRotateNextRotor() => _notches.Any(n => n == _rotation);

        public void Rotate() =>
            _rotation = _rotation == Letters.Length
                ? 1
                : _rotation + 1;

        public int GetPosition() => _rotation;

        private int GetPin(int pin)
        {
            var shiftedPin = pin + _rotation - 1;
            return shiftedPin >= Letters.Length 
                ? shiftedPin - Letters.Length 
                : shiftedPin;
        }

        internal int EncryptPinForth(int inputPin) => GetOutputPin(Letters, Map, GetPin(inputPin));

        internal int EncryptPinBack(int inputPin) => GetOutputPin(Map, Letters, GetPin(inputPin));
    }
}
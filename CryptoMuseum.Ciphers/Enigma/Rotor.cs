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

        private int AddRotation(int inputPin)
        {
            var shiftedPin = inputPin + _rotation - 1;
            return shiftedPin >= Letters.Length
                ? shiftedPin - Letters.Length
                : shiftedPin;
        }

        private int SubtractRotation(int inputPin)
        {
            var shiftedPin = inputPin - _rotation + 1;
            return shiftedPin < 0
                ? shiftedPin + Letters.Length
                : shiftedPin;
        }

        internal int EncryptPinForth(int inputPin) => EncryptPin(inputPin, Letters, Map);
        internal int EncryptPinBack(int inputPin) => EncryptPin(inputPin, Map, Letters);
        private int EncryptPin(int inputPin, string input, string output)
        {
            var rotatedPin = AddRotation(inputPin);
            var outputPinWithRotation = GetOutputPin(input, output, rotatedPin);
            var outputPinWithOutRotation = SubtractRotation(outputPinWithRotation);
            return outputPinWithOutRotation;
        }
    }
}
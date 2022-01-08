using System;
using System.Linq;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Rotor is moving component of Enigma
    /// </summary>
    public class Rotor : PinMap
    {
        private readonly int[] _notches;
        private int _rotation;
        private readonly int _startPosition;

        /// <summary>
        /// Create Rotor. Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        /// <param name="notches">Marks position of rotor, when it should rotate also rotor following after this one.</param>
        /// <param name="rotation">Set starting position of rotor.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Rotor(string map, int[] notches, int rotation) : base(map)
        {
            if (rotation < 1 || rotation > map.Length)
                throw new ArgumentOutOfRangeException(nameof(rotation),
                    $"Value must fit into map parameter length range (1-{map.Length})");

            if (notches.Min() < 1 || notches.Max() > map.Length)
                throw new ArgumentOutOfRangeException(nameof(notches),
                    $"Values must fit into map parameter length range (1-{map.Length})");

            _notches = notches.Distinct().ToArray();
            _rotation = rotation;
            _startPosition = rotation;
        }

        /// <summary>
        /// Reset rotor to starting position
        /// </summary>
        public void Reset() => _rotation = _startPosition;

        /// <summary>
        /// Checks if next rotor will rotate too due to notch presence at current rotor position.
        /// </summary>
        /// <returns></returns>
        public bool ShouldRotateNextRotor() => _notches.Any(n => n == _rotation);

        /// <summary>
        /// Rotates rotor to next position
        /// </summary>
        public void Rotate() =>
            _rotation = _rotation == Letters.Length
                ? 1
                : _rotation + 1;

        /// <summary>
        /// Gets rotor position
        /// </summary>
        /// <returns>returns position</returns>
        public int GetPosition() => _rotation;

        /// <summary>
        /// Gets pin shifted according to rotor position adding
        /// </summary>
        /// <param name="inputPin">pin to be shifted</param>
        /// <returns>index of pin after shifting</returns>
        private int AddRotation(int inputPin)
        {
            var shiftedPin = inputPin + _rotation - 1;
            return shiftedPin >= Letters.Length
                ? shiftedPin - Letters.Length
                : shiftedPin;
        }

        /// <summary>
        /// Gets pin shifted according to rotor position subtraction
        /// </summary>
        /// <param name="inputPin">pin to be shifted</param>
        /// <returns>index of pin after shifting</returns>
        private int SubtractRotation(int inputPin)
        {
            var shiftedPin = inputPin - _rotation + 1;
            return shiftedPin < 0
                ? shiftedPin + Letters.Length
                : shiftedPin;
        }

        /// <summary>
        /// Translates pin when going forth through rotor
        /// </summary>
        /// <param name="inputPin">input pin</param>
        /// <returns>output pin</returns>
        internal int EncryptPinForth(int inputPin) => EncryptPin(inputPin, Letters, Map);

        /// <summary>
        /// Translates pin when going back through rotor
        /// </summary>
        /// <param name="inputPin">input pin</param>
        /// <returns>output pin</returns>
        internal int EncryptPinBack(int inputPin) => EncryptPin(inputPin, Map, Letters);

        /// <summary>
        /// Translates pin when going through rotor
        /// </summary>
        /// <param name="inputPin">input pin</param>
        /// <param name="input">input map</param>
        /// <param name="output">output map</param>
        /// <returns>output pin</returns>
        private int EncryptPin(int inputPin, string input, string output)
        {
            var rotatedPin = AddRotation(inputPin);
            var outputPinWithRotation = GetOutputPin(input, output, rotatedPin);
            var outputPinWithOutRotation = SubtractRotation(outputPinWithRotation);
            return outputPinWithOutRotation;
        }
    }
}
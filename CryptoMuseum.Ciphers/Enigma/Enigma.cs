using System;
using System.Diagnostics;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Enigma - cipher machine
    /// </summary>
    public class Enigma : IEnigma
    {
        private readonly PlugBoard _plugBoard;
        private readonly Rotor[] _rotors;
        private readonly Reflector _reflector;

        /// <summary>
        /// Create Enigma machine by setting plugboard wiring and rotors
        /// </summary>
        /// <param name="reflector">reflector wiring</param>
        /// <param name="plugBoard">plugboard wiring</param>
        /// <param name="rotors">rotors - usually used 3 or more</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Enigma(Reflector reflector, PlugBoard plugBoard, params Rotor[] rotors)
        {
            _reflector = reflector;
            _plugBoard = plugBoard ?? throw new ArgumentNullException(nameof(plugBoard));
            _rotors = rotors ?? throw new ArgumentNullException(nameof(rotors));
        }

        /// <summary>
        /// Resets all rotors to starting position
        /// </summary>
        public void Reset()
        {
            foreach (var rotor in _rotors)
            {
                rotor.Reset();
            }
        }

        /// <summary>
        /// Press key on Enigma keyboard to be encrypted/decrypted
        /// </summary>
        /// <param name="c">key character</param>
        /// <returns>encrypted/decrypted character</returns>
        public char PressKey(char c)
        {
            var pin = GetKeyPin(c);
            pin = ApplyPlugboard(pin);
            pin = ApplyRotorsForth(pin);
            pin = ApplyReflector(pin);
            pin = ApplyRotorsBack(pin);
            pin = ApplyPlugboard(pin);

            var letter = PinMap.Letters[pin];

            Debug.WriteLine($"= Light up letter: {letter}");
            Debug.Flush();

            return letter;
        }

        private static int GetKeyPin(char c)
        {
            var pin = PinMap.Letters.IndexOf(c);
            Debug.WriteLine($">>> Pressed key: {c}, keyboard pin: {pin}");
            return pin;
        }

        private int ApplyPlugboard(int pin)
        {
            var encryptedPin = _plugBoard.EncryptPin(pin);
            Debug.WriteLine($"Plugboard translation to pin: {encryptedPin}");
            return encryptedPin;
        }

        private int ApplyRotorsForth(int pin)
        {
            var encryptedPin = pin;

            var shouldRotateNext = true;
            for (var i = 0; i < _rotors.Length; i++)
            {
                Debug.WriteLine($"Rotor[{i}]");
                Debug.Indent();

                if (shouldRotateNext)
                {
                    shouldRotateNext = _rotors[i].ShouldRotateNextRotor();
                    _rotors[i].Rotate();

                    Debug.WriteLine("Rotates");
                    Debug.WriteLineIf(shouldRotateNext, "Next rotor should rotate too.");
                }

                encryptedPin = _rotors[i].EncryptPinForth(encryptedPin);
                Debug.WriteLine($"Rotor translation to pin: {encryptedPin}");
                Debug.Unindent();
            }

            return encryptedPin;
        }

        private int ApplyReflector(int pin)
        {
            var encryptedPin = _reflector.EncryptPin(pin);
            Debug.WriteLine($"Reflector translation to pin: {pin}");
            return encryptedPin;
        }

        private int ApplyRotorsBack(int pin)
        {
            var encryptedPin = pin;
            for (var i = _rotors.Length - 1; i >= 0; i--)
            {
                encryptedPin = _rotors[i].EncryptPinBack(encryptedPin);
                Debug.WriteLine($"Rotor[{i}] translation to pin: {encryptedPin}");
            }

            return encryptedPin;
        }
    }
}
using System.Diagnostics;

namespace CryptoMuseum.Ciphers.Enigma
{
    public class Enigma
    {
        private readonly PlugBoard _plugBoard;
        private readonly Rotor[] _rotors;
        private readonly Reflector _reflector = Reflector.Default;

        public Enigma(PlugBoard plugBoard, params Rotor[] rotors)
        {
            _plugBoard = plugBoard;
            _rotors = rotors;
        }

        public void Reset()
        {
            foreach (var rotor in _rotors)
            {
                rotor.Reset();
            }
        }
        
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

            // TODO eval rotation all at once and do all rotations together

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
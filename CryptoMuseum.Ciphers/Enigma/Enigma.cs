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
            var pin = PinMap.Letters.IndexOf(c);
            Debug.WriteLine($">>> Pressed key: {c}, keyboard pin: {pin}");

            pin = _plugBoard.EncryptPin(pin);
            Debug.WriteLine($"Plugboard translation to pin: {pin}");
            
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
                    Debug.WriteLineIf(shouldRotateNext,"Next rotor should rotate too.");
                }

                pin = _rotors[i].EncryptPinForth(pin);
                Debug.WriteLine($"Rotor translation to pin: {pin}");
                Debug.Unindent();
            }

            pin = _reflector.EncryptPin(pin);
            Debug.WriteLine($"Reflector translation to pin: {pin}");
            
            for (var i = _rotors.Length - 1; i >= 0; i--)
            {
                pin = _rotors[i].EncryptPinBack(pin);
                Debug.WriteLine($"Rotor[{i}] translation to pin: {pin}");
            }

            pin = _plugBoard.EncryptPin(pin);
            Debug.WriteLine($"Plugboard translation to pin: {pin}");

            var letter = PinMap.Letters[pin];
            Debug.WriteLine($"= Light up letter: {letter}");

            Debug.Flush();

            return letter;
        }
    }
}
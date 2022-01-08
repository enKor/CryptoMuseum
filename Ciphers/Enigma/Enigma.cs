namespace Ciphers.Enigma
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

        public char PressLetter(char c)
        {
            var pin = PinMap.Letters.IndexOf(c);
            pin = _plugBoard.EncryptPin(pin);

            var shouldRotateNext = true;
            for (var i = 0; i < _rotors.Length; i++)
            {
                if (shouldRotateNext)
                {
                    shouldRotateNext = _rotors[i].ShouldRotateNextRotor();
                    _rotors[i].Rotate();
                }

                pin = _rotors[i].EncryptPinForth(pin);
            }

            pin = _reflector.EncryptPin(pin);

            for (var i = _rotors.Length - 1; i >= 0; i--)
            {
                pin = _rotors[i].EncryptPinBack(pin);
            }

            pin = _plugBoard.EncryptPin(pin);
            return PinMap.Letters[pin];
        }
    }
}
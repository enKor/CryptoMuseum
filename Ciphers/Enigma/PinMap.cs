namespace Ciphers.Enigma
{
    public abstract class PinMap
    {
        public const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        protected readonly string Map;

        /// <summary>
        /// Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        protected PinMap(string map)
        {
            // TODO check mapping
            Map = map;
        }

        protected internal static int GetOutputPin(string input, string output, int inputPin)
        {
            var c = output[inputPin];
            var outPin = input.IndexOf(c);
            return outPin;
        }
    }
}
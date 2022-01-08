using System;
using System.Linq;

namespace CryptoMuseum.Ciphers.Enigma
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
            if (string.IsNullOrEmpty(map))
                throw new ArgumentNullException(nameof(map), "Parameter cannot be null or empty.");

            if (map.Length != Letters.Length)
                throw new ArgumentException($"Parameter length must be exactly {Letters.Length} chars.", nameof(map));

            if (map.GroupBy(c => c).Any(g => g.Count() > 1))
                throw new ArgumentException("All characters must be unique.", nameof(map));

            if (map.Intersect(Letters).Count() != Letters.Length)
                throw new ArgumentException("Value must be composed only of following characters: " + Letters,
                    nameof(map));

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
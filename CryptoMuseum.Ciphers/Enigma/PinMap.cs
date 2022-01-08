using System;
using System.Linq;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Base class for any mapping (wiring) components of Enigma
    /// </summary>
    public abstract class PinMap
    {
        /// <summary>
        /// Characters set to be mapped
        /// </summary>
        public const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        protected readonly string Map;

        /// <summary>
        /// Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Get pin wiring translation
        /// </summary>
        /// <param name="input">input wires</param>
        /// <param name="output">output wires</param>
        /// <param name="inputPin">input pin</param>
        /// <returns>translated pin</returns>
        protected internal static int GetOutputPin(string input, string output, int inputPin)
        {
            var c = output[inputPin];
            var outPin = input.IndexOf(c);
            return outPin;
        }
    }
}
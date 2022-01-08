using System;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Plugboard is static component of Enigma
    /// </summary>
    public class PlugBoard : StaticPinMap
    {
        /// <summary>
        /// Plugboard with no wires plugged in.
        /// </summary>
        public static readonly PlugBoard WithNoMapping = new(Letters);

        /// <summary>
        /// Create plugboard. Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public PlugBoard(string map) : base(map)
        {
        }
    }
}
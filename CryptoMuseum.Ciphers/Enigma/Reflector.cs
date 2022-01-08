using System;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Reflector is static component of Enigma
    /// </summary>
    internal class Reflector : StaticPinMap
    {
        /// <summary>
        /// Default reflector
        /// </summary>
        public static readonly Reflector Default = new("YRUHQSLDPXNGOKMIEBFZCWVJAT");

        /// <summary>
        /// Create reflector. Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        private Reflector(string map) : base(map)
        {

        }
    }
}
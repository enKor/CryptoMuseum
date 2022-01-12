using System;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Reflector is static component of Enigma aka UKW
    /// </summary>
    public class Reflector : StaticPinMap
    {
        /// <summary>
        /// Create reflector. Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Reflector(string map) : base(map)
        {

        }
    }
}
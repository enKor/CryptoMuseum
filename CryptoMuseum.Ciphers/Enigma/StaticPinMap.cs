using System;

namespace CryptoMuseum.Ciphers.Enigma
{
    /// <summary>
    /// Base class for any static mapping (wiring) components of Enigma
    /// </summary>
    public abstract class StaticPinMap : PinMap
    {
        /// <summary>
        /// Reflects A-Z mapping
        /// </summary>
        /// <param name="map">A-Z map translation</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        protected StaticPinMap(string map) : base(map)
        {

        }

        /// <summary>
        /// Translates input pin to output pin
        /// </summary>
        /// <param name="inputPin">input pin</param>
        /// <returns>output pin</returns>
        public int EncryptPin(int inputPin) => GetOutputPin(Letters, Map, inputPin);
    }
}
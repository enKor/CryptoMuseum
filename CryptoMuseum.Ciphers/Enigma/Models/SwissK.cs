namespace CryptoMuseum.Ciphers.Enigma.Models
{
    /// <summary>
    /// Swiss K; February 1939
    /// </summary>
    public class SwissK : Enigma
    {
        public const string IK = "PEZUOHXSCVFMTBGLRINQJWAYDK";
        public const string IIK = "ZOUESYDKFWPCIQXHMVBLGNJRAT";
        public const string IIIK = "EHRVXGAOBQUSIMZFLYNWKTPDJC";
        private const string UKWK = "IMETCGFRAYSQBZXWLHKDVUPOJN";

        public SwissK(PlugBoard etw, params Rotor[] rotors)
            : base(new Reflector(UKWK), etw, rotors)
        {

        }
    }
}
namespace CryptoMuseum.Ciphers.Enigma.Models
{
    /// <summary>
    /// German Railway (Rocket); 7 February 1941
    /// </summary>
    public class GermanRailwayRocket : Enigma
    {
        public const string IC = "JGDQOXUSCAMIFRVTPNEWKBLZYH";
        public const string IIC = "NTZPSFBOKMWRCJDIVLAEYUXHGQ";
        public const string IIIC = "JVIUBHTCDYAKEQZPOSGXNRMWFL";
        private const string UKW = "QYHOGNECVPUZTFDJAXWMKISRBL";

        public GermanRailwayRocket(PlugBoard etw, params Rotor[] rotors)
            : base(new Reflector(UKW), etw, rotors)
        {

        }
    }
}
using Org.BouncyCastle.Asn1.X9;

namespace BeHeroes.Blockchainification.Core.Cryptography.Algorithms
{
    public sealed class Secp256k1Curve : BeHeroes.CodeOps.Abstractions.Cryptography.Structure
    {
        public static string Name => "secp256k1";

        public Secp256k1Curve(byte[]? seed = default) : base(Name, seed ?? ECNamedCurveTable.GetByName(Name).GetSeed())
        {
            
        }
    }
}
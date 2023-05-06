using BeHeroes.Blockchainification.Core.Cryptography.Algorithms;
using BeHeroes.CodeOps.Abstractions.Cryptography;

using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace BeHeroes.Blockchainification.Core.Cryptography
{
    public sealed class Ed25519KeyPair : IKeyPair
    {
        public IAlgorithm Algorithm { get; init; }

        public IKey Private { get; init; }

        public IKey Public { get; init; }

        public Ed25519KeyPair() : this(new Ed25519Algorithm())
        {        
        }
        
        public Ed25519KeyPair(Ed25519Algorithm algorithm)
        {
            Algorithm = algorithm;

            var curve = Algorithm.Structure as Curve25519;

            if(curve == null)
                throw new CryptographyException($"Unsupported structure identified in algorithm {nameof(Ed25519Algorithm)}. Expected {nameof(Curve25519)}");
            
            var generator = new Ed25519KeyPairGenerator();
            var keyGenerationParams = new Ed25519KeyGenerationParameters(new SecureRandom());
            
            generator.Init(keyGenerationParams);

            var keyPair = generator.GenerateKeyPair();
            var privateKeyParameter = (Ed25519PrivateKeyParameters)keyPair.Private;
            var publicKeyParameter = (Ed25519PublicKeyParameters)keyPair.Public;

            Private = new Ed25519Key(privateKeyParameter.GetEncoded());
            Public = new Ed25519Key(publicKeyParameter.GetEncoded(), false);
        }
    }
}
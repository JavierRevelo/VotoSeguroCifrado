using System;
using System.Numerics;

namespace VotoSeguro.Algorithms
{
    public static class ElGamal
    {
        public static Tuple<BigInteger, BigInteger> Encrypt(BigInteger plaintext, BigInteger publicKey, BigInteger generator, BigInteger modulus)
        {
            Random rand = new Random();
            BigInteger k = new BigInteger();
            BigInteger ciphertext1 = new BigInteger();
            BigInteger ciphertext2 = new BigInteger();

            do
            {
                k = BigInteger.Remainder(new BigInteger(rand.Next()), modulus - 1);
            }
            while (BigInteger.GreatestCommonDivisor(k, modulus - 1) != 1);

            ciphertext1 = BigInteger.ModPow(generator, k, modulus);
            ciphertext2 = (BigInteger.Pow(publicKey, (int)k) * plaintext) % modulus;

            return new Tuple<BigInteger, BigInteger>(ciphertext1, ciphertext2);
        }

        public static BigInteger Decrypt(Tuple<BigInteger, BigInteger> ciphertext, BigInteger privateKey, BigInteger modulus)
        {
            BigInteger plaintext = (BigInteger.Pow(ciphertext.Item1, (int)privateKey) * ciphertext.Item2) % modulus;
            return plaintext;
        }
    }
}

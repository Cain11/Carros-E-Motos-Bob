using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarrosMotosBob
{
    public static class UtilSenha
    {
        private const int TamanhoSalt = 16;
        private const int TamanhoHash = 32;

        private static byte[] GerarHashSenha(string senha, byte[] salt)
        {
            byte[] hashFinal = new byte[TamanhoHash + TamanhoSalt];
            byte[] hash;

            using (var rfc2898 = new Rfc2898DeriveBytes(senha, salt))
                hash = rfc2898.GetBytes(TamanhoHash);

            salt.CopyTo(hashFinal, 0);
            hash.CopyTo(hashFinal, TamanhoSalt);

            return hashFinal;
        }

        public static byte[] GerarHashSenha(string senha)
        {
            byte[] salt = new byte[TamanhoSalt];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            return GerarHashSenha(senha, salt);
        }

        public static bool ValidarSenha(byte[] hash, string senha)
        {
            byte[] salt = new byte[TamanhoSalt];
            Array.Copy(hash, 0, salt, 0, TamanhoSalt);

            byte[] hashSenha = GerarHashSenha(senha, salt);

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != hashSenha[i]) return false;
            }

            return true;
        }

    }
}

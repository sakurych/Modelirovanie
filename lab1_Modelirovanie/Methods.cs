using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace lab1_Modelirovanie
{
    internal class Methods
    {
        public uint Xi = 65539;
        public static ulong X0i = 2147483648;
        public int standartMethod() // встроенный
        {
            Random rnd = new Random(RandomMultiCompar());
            int stndrt = rnd.Next();
            return stndrt;
        }

        public int RandomMultiCompar() /// Метод вычетов
        {
            uint m = 2147483647;
            uint a = 65539;
            Xi = (a * Xi) % m;
            return (int)Xi;
        }

        public int CryptoRNG()
        {
            int value = 0;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                value = BitConverter.ToInt32(data, 0);
            }
            return value;
        }
    }
}
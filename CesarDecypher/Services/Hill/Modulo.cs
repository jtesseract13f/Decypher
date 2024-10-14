using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public static class Modulo
    {
        public static int InverseModulo(this int n, int modulo)
        {
            //n = n.ToPositive(modulo);
            for (int i = 2; i < modulo; ++i)
            {
                if (Gcd(modulo, n*i) == 1)
                {
                    return i;
                }
            }
            throw new Exception($"Взаимообратных чисел не существует для числа {n} по модулю {modulo}");
        }

        public static int ToPositive(this int n, int modulo) 
        {
            return (n % modulo + modulo)%modulo;
        }

        public static int Gcd(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            return Gcd(b % a, a);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public static class ModularArithmetics
    {
        public static int FindNod(int a, int b) // NEED TO TEST, or check alg
        {
            a = a > b ? a : b;
            b = a > b ? b : a;
            if (b <= 1)
            {
                return a;
            }
            return FindNod(b, a % b);
        }
    }

}

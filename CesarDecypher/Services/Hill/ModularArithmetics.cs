using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public static class ModularArithmetics
    {
        public static int FindNod(int a, int b) 
        {
            if (a < b) { int temp = a; a = b; b = temp; }
            if (b == 0)
            {
                return a;
            }
            return FindNod(b, a % b);
        }

        public static (int, int, int) GcdExtend(int a, int b)
        {
            if (a == 0)
            {
                return (b, 0, 1);
            }
            int x1, y1, d;
            (x1, y1, d) = GcdExtend(b%a, a);
            
            return (d, y1 - (b / a) * x1, x1);
        }

        public static int toPositive(this int a, int n)
        {
            int res = (a % n + n) % n;
            return res;
        }

    }

}

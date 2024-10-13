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
        
    }

}

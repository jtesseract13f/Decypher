using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.KeyGens
{
    public static class BackpackKeyGen
    {
        public static List<int> GenClosedKey(int length)
        {
            var closedKey = new List<int>() {1};
            var rand = new Random();
            for (int i = 1; i < length; ++i)
            {
                closedKey.Add(closedKey.Sum()+(rand.Next()%19+1));
            }
            return closedKey;
        }

        public static List<int> GenOpenKey(List<int> closedKey, int modulo)
        {
            var res = new List<int>();
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Infrasturcture
{
    public class Alphabet
    {
        Dictionary<char, int> charToInt;
        char[] intToChar;
        public int Size { get; set; }

        public Alphabet(char[] alphabet)
        {
            charToInt = new Dictionary<char, int>();
            intToChar = alphabet;
            Size = alphabet.Length;

            for (int i = 0; i < alphabet.Length; i++) {
                charToInt[alphabet[i]] = i;
            }
        }

        public int ToInt(char c) {
            if (!charToInt.ContainsKey(c)) {
                throw new Exception($"Ошибка кодирования: символ {c} отсутствует в алфавите");
            }
            return charToInt[c];
        }

        public List<int> ToInt(string str)
        {
            var res  = new List<int>();
            for (int i = 0; i < str.Length; ++i)
            {
                res.Add(ToInt(str[i]));
            }
            return res;
        }

        public char ToChar(int n)
        {
            if (n < 0 || n >= charToInt.Count) { throw new Exception($"Ошибка кодирования: индекс {n} отсутствует в алфавите"); }
            return intToChar[n];
        }

        public string ToString(List<int> ns)
        {
            var str = new StringBuilder("");

            foreach (var n in ns)
            {
                str.Append(ToChar(n));
            }
            return str.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherLogic.Services
{
    public class FrequencyAnalysator
    {
        public Dictionary<char, double> FrequencyAnalys = new Dictionary<char, double>();
        public char[] alphabet;

        public FrequencyAnalysator(char[] _alphabet)
        {
            alphabet = _alphabet;
        }
        public void GetFrequency(string message)
        {
            FrequencyAnalys = new Dictionary<char, double>();
            int count = 0;
            message = message.ToLower();
            for (int i = 0; i < message.Length; ++i)
            {
                if (alphabet.Contains(message[i]))
                {
                    if (FrequencyAnalys.ContainsKey(message[i]))
                    {
                        ++FrequencyAnalys[message[i]];
                    }
                    else
                    {
                        FrequencyAnalys.Add(message[i], 1.0);
                    }
                    ++count;
                }
                
            }

            foreach (var chr in alphabet)
            {
                if (!FrequencyAnalys.ContainsKey(chr))
                {
                    FrequencyAnalys.Add(chr, 0);
                }
                FrequencyAnalys[chr] /= count;
            }
        }
        public void GetFrequency(string message, char[] alphabet)
        {
            FrequencyAnalys = new Dictionary<char, double>();
            Dictionary<char, int> a = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; ++i)
            {
                a.Add(alphabet[i], i);
            }
            message = message.ToLower();
            int[] charNumbers = new int[alphabet.Length];
            int count = 0;
            for (int i = 0; i < message.Length; ++i)
                if (alphabet.Contains(message[i]))
                {
                    ++charNumbers[a[message[i]]];
                    ++count;
                }
            if (count > 0)     
                for (int i = 0; i <  charNumbers.Length; i++)
                {
                    FrequencyAnalys.Add(alphabet[i], (double)charNumbers[i] / count);
                }
        }
    }
}

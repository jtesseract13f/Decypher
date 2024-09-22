using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherLogic.Services
{
    public class FrequencyAnalysator
    {
        public Dictionary<char, double> FrequencyAnalys;
        public void GetFrequency(string message)
        {
            
        }
        public void GetFrequency(string message, char[] alphabet)
        {
            int[] charNumbers = new int[alphabet.Length];
            int count = 0;
            for (int i = 0; i < message.Length; ++i)
                if (alphabet.Contains(message[i]))
                {
                    ++charNumbers[message[i]];
                    ++count;
                }
                    
            for (int i = 0; i <  charNumbers.Length; i++)
            {
                FrequencyAnalys.Add(alphabet[i], charNumbers[i] / count);
            }
        }
    }
}

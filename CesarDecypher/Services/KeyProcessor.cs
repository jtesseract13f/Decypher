﻿using CypherLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services
{
    public class KeyProcessor
    {
        readonly Dictionary<char, double> letterFrequencies = new Dictionary<char, double>
            {
                { 'a', 8.17 },
                { 'b', 1.49 },
                { 'c', 2.78 },
                { 'd', 4.25 },
                { 'e', 12.70 },
                { 'f', 2.23 },
                { 'g', 2.02 },
                { 'h', 6.09 },
                { 'i', 6.97 },
                { 'j', 0.15 },
                { 'k', 0.77 },
                { 'l', 4.03 },
                { 'm', 2.41 },
                { 'n', 6.75 },
                { 'o', 7.51 },
                { 'p', 1.93 },
                { 'q', 0.10 },
                { 'r', 5.99 },
                { 's', 6.33 },
                { 't', 9.06 },
                { 'u', 2.76 },
                { 'v', 0.98 },
                { 'w', 2.36 },
                { 'x', 0.15 },
                { 'y', 1.97 },
                { 'z', 0.07 }
            };
        readonly Dictionary<char, double> russianLetterFrequencies = new Dictionary<char, double>
            {
                { 'о', 10.983 },
                { 'е', 8.483 },
                { 'а', 7.998 },
                { 'и', 7.367 },
                { 'н', 6.7 },
                { 'т', 6.318 },
                { 'с', 5.473 },
                { 'р', 4.746 },
                { 'в', 4.533 },
                { 'л', 4.343 },
                { 'к', 3.486 },
                { 'м', 3.203 },
                { 'д', 2.977 },
                { 'п', 2.804 },
                { 'у', 2.615 },
                { 'я', 2.001 },
                { 'ы', 1.898 },
                { 'ь', 1.735 },
                { 'г', 1.687 },
                { 'з', 1.641 },
                { 'б', 1.592 },
                { 'ч', 1.45 },
                { 'й', 1.208 },
                { 'х', 0.966 },
                { 'ж', 0.94 },
                { 'ш', 0.718 },
                { 'ю', 0.638 },
                { 'ц', 0.486 },
                { 'щ', 0.361 },
                { 'э', 0.331 },
                { 'ф', 0.267 },
                { 'ъ', 0.037 },
                { 'ё', 0.013 }
            };

        public double GetPOWER(string message)
        {
            double russianPower = 0;
            double cringePower = 0;

            foreach(var c in message)
            {
                if (russianLetterFrequencies.ContainsKey(c))
                {
                    russianPower += russianLetterFrequencies[c];
                }
                if (letterFrequencies.ContainsKey(c))
                {
                    cringePower += letterFrequencies[c];
                }
            }

            return cringePower > russianPower ? cringePower : russianPower;
        }

        public int ProcessKey(char[] alphabet, string message)
        {
            Dictionary<char, char> monoalphabet = new Dictionary<char, char>();
            int key = 0;
            double POWER = 0;
            for (int i = 0; i < alphabet.Length; i++) 
            {
                Cesar cesar = new Cesar(i, alphabet);
                double temp = GetPOWER(cesar.Decrypt(message.ToLower()));
                if (temp > POWER) 
                {
                    key = i;
                    POWER = temp;
                }
            }
            return key; 
        }

        public string ProcessMonoalphabet(char[] alphabet, string message)
        {
            return "";
        }
    }
}

using CypherLogic.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherLogic.Services
{
    public class Vigenere : IEncryptor
    {
        public string AlghorithmName { get => "Vigenere Encryptor"; set => value = "Vigenere Encryptor"; }
        string key;
        public char[] alphabet;
        public Dictionary<char, int> alphabetVa;
        public Dictionary<char, Dictionary<char, char>> VigenereTable;
        public Vigenere(string _key, char[] _alphabet)
        {
            key = _key;
            alphabet = _alphabet;
            VigenereTable = new Dictionary<char, Dictionary<char, char>>();
            for (int i = 0; i < _alphabet.Length; i++) 
            {
                Dictionary<char, char> temp = new Dictionary<char, char>();
                for (int j = 0; j < _alphabet.Length; ++j)
                {
                    temp.Add(alphabet[j], alphabet[(j+i)%alphabet.Length]);
                }
                VigenereTable.Add(alphabet[i], temp);
            }
        }
        public string Encrypt(string message)
        {
            StringBuilder encryptMessage = new StringBuilder(message);
            int position = 0;
            for (int i = 0; i < encryptMessage.Length; ++i)
            {
                if (alphabet.Contains(encryptMessage[i]))
                {
                    encryptMessage[i] = VigenereTable[encryptMessage[i]][key[position]];
                    ++position;
                    position %= key.Length;
                } else if (alphabet.Contains(encryptMessage[i].ToString().ToLower()[0]))
                {
                    encryptMessage[i] = VigenereTable[encryptMessage[i].ToString().ToLower()[0]][key[position]].ToString().ToUpper()[0];
                    ++position;
                    position %= key.Length;
                }
                
            }
            return encryptMessage.ToString();
        }

        public string Decrypt(string message)
        {
            StringBuilder decryptMessage = new StringBuilder(message);
            int position = 0;
            for (int i = 0; i < decryptMessage.Length; ++i)
            {
                if (alphabet.Contains(decryptMessage[i]))
                {
                    decryptMessage[i] = VigenereTable[key[position]].First(x => x.Value == decryptMessage[i]).Key;
                    ++position;
                    position %= key.Length;
                } else if (alphabet.Contains(decryptMessage[i].ToString().ToLower()[0]))
                {
                    decryptMessage[i] = VigenereTable[key[position]].First(x => x.Value == decryptMessage[i].ToString().ToLower()[0]).Key.ToString().ToUpper()[0];
                    ++position;
                    position %= key.Length;
                }

            }
            return decryptMessage.ToString();
        }
    }
}

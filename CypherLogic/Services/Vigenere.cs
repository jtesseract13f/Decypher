using CypherLogic.Interfaces;
using System;
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

        public Vigenere(string _key, char[] _alphabet)
        {
            key = _key;
            alphabet = _alphabet;
            alphabetVa = new Dictionary<char, int>();
            for (int i = 0; i < _alphabet.Length; i++) 
            {
                alphabetVa[alphabet[i]] = i;
            }
        }
        public string Encrypt(string message)
        {
            StringBuilder encryptMessage = new StringBuilder(message);

            for (int i = 0; i < encryptMessage.Length; ++i)
            {
                encryptMessage[i] = alphabet[alphabetVa[key[i % key.Length]]];
            }

            return encryptMessage.ToString();
        }

        public string GetDecryptkey()
        {
            StringBuilder decryptKey = new StringBuilder(key);
            for (int i = 0; i <  decryptKey.Length; ++i)
            {
                decryptKey[i] = alphabet[alphabet.Length - alphabetVa[decryptKey[i]]];
            }

            return decryptKey.ToString();
        }

        public string Decrypt(string message)
        {
            key = GetDecryptkey();
            return Encrypt(message);
        }
    }
}

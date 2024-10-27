using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherLogic.Services
{
    public class Cesar : ICypher
    {
        private int key;
        public char[] alphabet;
        public Dictionary<char, char> encryptor;
        public string AlghorithmName { get; set; }

        public Cesar(int _key, char[] _alphabet)
        {
            key = _key;
            alphabet = _alphabet;
            AlghorithmName = "Caesar Encryptor";

            encryptor = new Dictionary<char, char>();

            for (int i = 0; i < _alphabet.Length; ++i)
            {
                encryptor[alphabet[i]] = alphabet[(i + key) % alphabet.Length];
            }
        }
        public string Encrypt(string message)
        {
            StringBuilder encryptMessage = new StringBuilder(message);
            for (int i = 0; i < message.Length; ++i)
            {
                if (alphabet.Contains(encryptMessage[i]))
                    encryptMessage[i] = encryptor[message[i]];
                else if (alphabet.Contains(encryptMessage[i].ToString().ToLower()[0])){
                    encryptMessage[i] = encryptor[message[i].ToString().ToLower()[0]].ToString().ToUpper()[0];
                }
            }
            return encryptMessage.ToString();
        }

        public string Decrypt(string message)
        {
            key = alphabet.Length - key;
            encryptor = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; ++i)
            {
                encryptor[alphabet[i]] = alphabet[(i + key) % alphabet.Length];
            }
            return Encrypt(message);
        }
    }
}

using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherLogic.Services
{
    public class MonoAlphabet : ICypher
    {
        public string AlghorithmName { get; set; }
        public char[] alphabet;
        public char[] key;
        public Dictionary<char, char> encryptor;
        public Dictionary<char, char> decryptor;

        public MonoAlphabet(char[] _key, char[] _alphabet)
        {
            key = _key;
            alphabet = _alphabet;
            AlghorithmName = "MonoAlphabet Encryptor";

            encryptor = new Dictionary<char, char>();
            decryptor = new Dictionary<char, char>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                encryptor[alphabet[i]] = _key[i];
                decryptor[_key[i]] = alphabet[i];
            }

        }

        public string Encrypt(string message)
        {
            StringBuilder encryptMessage = new StringBuilder(message);
            for (int i = 0; i < message.Length; ++i)
            {
                if (encryptor.ContainsKey(message[i]))
                    encryptMessage[i] = encryptor[message[i]];
            }

            return encryptMessage.ToString();
        }

        public string Decrypt(string message)
        {
            StringBuilder decryptMessage = new StringBuilder(message);
            for (int i = 0; i < message.Length; ++i)
            {
                if (decryptor.ContainsKey(message[i]))
                    decryptMessage[i] = decryptor[message[i]];
            }
            return decryptMessage.ToString();
        }
    }
}

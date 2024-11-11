using CesarDecypher.Infrasturcture;
using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Cyphers
{
    public class Hill : ICypher
    {
        public char[] _alphabet;
        public Dictionary<char, int> _charToInt;
        public string AlghorithmName { get; set; }
        public List<List<int>> _key;

        public Hill(char[] alphabet, string key)
        {
            _key = ParseKey(key);
            _alphabet = alphabet;
            _charToInt = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++) {
                _charToInt[alphabet[i]] = i;
            }
        }
        public string Decrypt(string message)
        {
            _key = _key.InverseModulo(_alphabet.Length).Select(x=>x.Select(i => i.ToPositive(_alphabet.Length)).ToList()).ToList();
            return Encrypt(message);
        }

        public static List<List<int>> ParseKey(string key) 
        {
            var columns = key.Split(';');
            var matrix = columns.Select(x => x.Split(' ', ','));
            return matrix.Select(x => x.Select(y => int.Parse(y)).ToList()).ToList();
        }

        public string Encrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder("");
            for (int i = 0; i < message.Length; i += _key[0].Count)
            {
                var block = GetBlock(message, i, _key[0].Count);
                block = _key.Multiply(block).Select(x=>x.Select(y=>y%_alphabet.Length).ToList()).ToList();
                
                encryptedMessage.Append(BlockToString(block).ToString());
            }

            return encryptedMessage.ToString();
        }
        public StringBuilder BlockToString(List<List<int>> block)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < block.Count; i++)
            {

                    builder.Append(_alphabet[(block[i][0].ToPositive(_alphabet.Length)) % _alphabet.Length]);
             
                    
            }
            return builder;
        }
        public List<List<int>> GetBlock(string message, int index, int count)
        {
            var block = new List<List<int>>() {};
            for (int i = index; i < count+index; ++i)
            {
                if (!(i < message.Length))
                {
                    block.Add(new List<int> { _charToInt[message[0]] });
                    continue;
                }
                block.Add(new List<int> { _charToInt[message[i]] });
            }
            return block;
        }
    }

    
}

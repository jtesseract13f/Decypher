using CypherLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public class Hill : IEncryptor
    {
        public string AlghorithmName { get; set; }
        public char[] alphabet;
        public Dictionary<char, int> alp;
        public List<List<int>> key;

        
        public Hill( char[] _alphabet)
        {
            AlghorithmName = "Hill";
            alphabet = _alphabet;
            alp = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++) {
                alp[alphabet[i]] = i;
            }
        }
        public bool CheckKey()
        {
            return true;
        }

        public void ParseKey(string _key)
        {
            var lines = _key.Split(';');
            key = new List<List<int>>();
            for (int i = 0; i < lines.Length; ++i)
            {
                key.Add(new List<int>());
                foreach (var num in lines[i].Split(' ', ',') )
                {
                    key[i].Add(int.Parse(num));
                }
            }
            StringBuilder str = new StringBuilder(alphabet.Length);
            for (int i = 0; i < alphabet.Length; ++i)
            {
                str.Append(alphabet[i]);
            }
            HillKeyGen.ValidateKey(key, str.ToString());
        }

        public string Decrypt(string message)
        {
            var matrix = new Matrix(key);
            var inverseMatrix = matrix.GetInverseMatrix(alphabet.Length);
            key = matrix.GetInverseMatrix(alphabet.Length);
            
            return Encrypt(message); ;
        }

        public string Encrypt(string message)
        {

            StringBuilder result = new StringBuilder(message);
            for (int i = 0; i < message.Length; i += key[0].Count)
            {
                List<int> part = new List<int>();
                for (int j = i; j < i+ key[0].Count; ++j)
                {
                    part.Add(alp[message[j]]);
                }
                var res = MatrixMagic(part, key);
                for (int j = 0; j < key[0].Count; ++j)
                {
                    result[j+i] = alphabet[res[j]];
                }
            }
            return result.ToString();
        }

        private List<int> MatrixMagic(List<int> part, List<List<int>> _key)
        {
            var result = new List<int>();
            for (int i = 0; i < _key[0].Count; ++i)
            {
                result.Add(0);
            }
            for (int i = 0; i < _key[0].Count; i++)
            {
                for (int j = 0; j < _key[0].Count; j++) {
                    result[i] += (part[j] * _key[i][j]).toPositive(alphabet.Length);
                }
            }
            for (int i = 0; i < _key[0].Count; ++i)
            {
                result[i] = result[i].toPositive(alphabet.Length);
            }
            return result;
        }
    }
}

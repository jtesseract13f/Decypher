using CesarDecypher.Infrasturcture;
using CesarDecypher.Interfaces;
using CesarDecypher.Services.Cyphers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.KeyHackers
{
    public class HillHacker : IKeyHacker
    {
        char[] alphabet;
        public Dictionary<char, int> _charToInt;

        string sourceText;
        string encryptedText;
        public int length = -1;

        public HillHacker(char[] _alphabet, string _sourceText, string _encryptedText, int _length)
        {
            alphabet = _alphabet;
            sourceText = _sourceText;
            encryptedText = _encryptedText;
            length = _length;
            _charToInt = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                _charToInt[alphabet[i]] = i;
            }
        }
        public string TryGetkey()
        {
            //var hillEncryptor = new Hill(alphabet, "5 4;3 1");
            return GetKeyMatrix().MatrixToString();
            // взять первые н символов
            // найти обратную по модулю матрицу
            // перемножить вектор символов на обратную матрицу
        }

        public List<List<int>> GetKeyMatrix()
        {
            var matrix = new List<List<int>>();
            for (int i = 0; i < length; ++i)
            {
                matrix.Add(new List<int>());
                for (int j = 0; j < length; ++j)
                {
                    matrix[i].Add(0);
                }
            }
            
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    matrix[i][j] = sourceText[(i*length + j)%sourceText.Length];
                }
            }

            var Y = new List<List<int>>();
            for (int i = 0; i < length; ++i)
            {
                Y.Add(new List<int>());
                for (int j = 0; j < length; ++j)
                {
                    Y[i].Add(0);
                }
            }

            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    Y[i][j] = encryptedText[(i * length + j) % encryptedText.Length];
                }
            }
            var key = matrix.InverseModulo(alphabet.Length);
            return key.Multiply(Y);
        }

        public List<List<int>> GetBlock(string message, int index, int count)
        {
            var block = new List<List<int>>() {};
            for (int i = index; i < count + index; ++i)
            {
                if (!(i < message.Length))
                {
                    block.Add(new List<int>() { _charToInt[message[0]] });
                    continue;
                }
                block.Add(new List<int>() { _charToInt[message[i]] }); ;
            }
            return block;
        }
    }
}

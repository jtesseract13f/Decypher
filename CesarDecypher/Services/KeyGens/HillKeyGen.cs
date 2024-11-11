using CesarDecypher.Interfaces;
using System;
using CesarDecypher.Services.Cyphers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CesarDecypher.Infrasturcture;

namespace CesarDecypher.Services.KeyGens
{
    public class HillKeyGen : IKeyGenerator
    {
        public char[] alphabet {  get; set; }

        public HillKeyGen(char[] _alphabet)
        {
            alphabet = _alphabet;
        }
        public string GenerateKey(int length)
        {
            if (length < 2 || length > 7)
            {
                throw new ArgumentException("Некорректная длина ключа. Размерность квадратной матрицы должна быть больше 2 и меньше 6");
            }
            var key = new List<List<int>>();
            for (int i = 0; i < length; i++) {
                key.Add(new List<int>());
                for (int j = 0; j < length; j++) {
                    key[i].Add(1);
                }
            }
            while (!ValidateKey(key))
            {
                key.RandomizeMatrix();
                for (int i = 0; i < key.Count; i++) {
                    for (int j = 0; j < key.Count; j++)
                    {
                        key[i][j] %= alphabet.Length;
                    }
                }
            }
            return key.MatrixToString();
        }

        public bool ValidateKey(List<List<int>> matrix)
        {
            try
            {
                // matrix.Determinant().InverseModulo(alphabet.Length);
                matrix.InverseModulo(alphabet.Length);
            }
            catch (Exception ex) 
            {
                return false;
            }
            return true;
        }
    }
}

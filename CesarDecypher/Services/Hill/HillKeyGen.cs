using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public class HillKeyGen
    {
        Matrix keyMatrix;
        char[] alphabet;
        public HillKeyGen() { }
        public int[,] GenKeyForHill(int matrixSize)
        {
            int[,] keyMatrix = new int[matrixSize, matrixSize];

            // TO DO : GEY KEN
            return keyMatrix;
        }

        public static void ValidateKey(List<List<int>> key, string _alphabet)
        {
            var matrix = new Matrix(key);
            var determinant = matrix.FindDeterminant();
            if (determinant == 0)
            {
                throw new Exception("Детерминант матрицы не должен быть равен нулю");
            }
            if (determinant < 0)
            {
                determinant =  _alphabet.Length - (-determinant % _alphabet.Length);
            }
            var t = ModularArithmetics.FindNod(determinant % _alphabet.Length, _alphabet.Length);
            if (t != 1)
            {
                throw new Exception("Детерминант матрицы не взаимнопростой с длиной алфавита");
            }

            var inverse = matrix.GetInverseMatrix(_alphabet.Length);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Services.Hill
{
    public class Matrix
    {
        List<List<int>> _matrix;

        public Matrix(List<List<int>> matrix)
        {
            _matrix = matrix;
        }
        public void FindDeterminant()
        {
            int determinant = 0;

            for (int i = 0; i < _matrix[0].Count; ++i)
            {
                int sign = (i + 0) % 2 == 0 ? -1 : 1;
                determinant += _matrix[i][0] * CalculateDeterminant(_matrix, i, 0);
            }
            determinant /= 2;
        }

        public static int CalculateDeterminant2X2(List<List<int>> matrix)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        public static int CalculateDeterminant(List<List<int>> matrix, int im, int jm = 0)
        {
            int determinant = 0;
            int sign = (im+jm)%2 == 0 ? -1 : 1;

            if (matrix[0].Count == 2)
            {
                return CalculateDeterminant2X2(matrix) * sign;
            }
            for (int i = 0; i < matrix[0].Count; ++i)
            {
                determinant += matrix[i][0] * CalculateDeterminant(GetMinorMatrix(matrix, i, jm), i, jm) * sign;
            }

            return determinant;
        }

        private static List<List<int>> GetMinorMatrix(List<List<int>> matrix, int im, int jm)
        {
            List<List<int>> newmatrix = new List<List<int>>();
            for (int i = 0; i < matrix[0].Count; ++i)
            {
                if (i == im) continue;
                newmatrix.Add(new List<int>());
                for (int j = 0; j < matrix[0].Count; ++j) // need to check
                {
                    if (j == jm) continue;
                    newmatrix.Last().Add(matrix[i][j]);
                }
            }
            return newmatrix;
        }
    }
}

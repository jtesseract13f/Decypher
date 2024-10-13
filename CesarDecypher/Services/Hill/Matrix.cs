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

        public List<List<int>> GetInverseMatrix(int n)
        {
            List<List<int>> inverseMatrix = new List<List<int>>();
            List<List<int>> friendlyMatrix = GetFriendlyMatrix();
            int determinant, x, y;
            determinant = FindDeterminant();
            (determinant, x, y) = ModularArithmetics.GcdExtend(n, determinant);
            for (int i = 0; i < _matrix[0].Count; ++i)
            {
                inverseMatrix.Add(new List<int>());
                for (int j = 0; j < _matrix[0].Count; ++j)
                {
                    inverseMatrix[i].Add(friendlyMatrix[i][j] * x);
                }
            }
            return inverseMatrix;
        }

        public List<List<int>> GetFriendlyMatrix()
        {
            List<List<int>> friendlyMatrix = new List<List<int>>();
            for (int i = 0; i < _matrix[0].Count; ++i)
            {
                friendlyMatrix.Add(new List<int>());
                for (int j = 0; j < _matrix[0].Count; ++j)
                {
                    friendlyMatrix[i].Add(0);
                }
            }
            for (int i = 0; i < _matrix[0].Count; ++i)
            {
                for (int j = 0; j < _matrix[0].Count; ++j)
                {
                    friendlyMatrix[i][j] = CalculateDeterminant(GetMinorMatrix(_matrix, i, j), i, j);
                }
            }
            var result = new List<List<int>>();

            for (int i = 0; i < _matrix[0].Count; ++i)
            {
                result.Add(new List<int>());
                for (int j = 0; j < _matrix[0].Count; ++j)
                {
                    result[i].Add(0);
                }
            }

            for (int i = 0; i < _matrix[0].Count; ++i)
            {
                for (int j = 0; j < _matrix[0].Count; ++j)
                {
                    result[j][i] = friendlyMatrix[i][j];
                }
            }

            return result;
        }
        public int FindDeterminant()
        {
            int determinant = CalculateDeterminant(_matrix, 0, 0);
            return determinant;
        }

        private int CalculateDeterminant2X2(List<List<int>> matrix)
        {
           
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        private int CalculateDeterminant(List<List<int>> matrix, int im, int jm = 0)
        {
            int determinant = 0;
            int sign = (im+jm)%2 == 0 ? 1 : -1;
            if (matrix[0].Count == 1)
            {
                return matrix[0][0] * sign;
            }
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

        private List<List<int>> GetMinorMatrix(List<List<int>> matrix, int im, int jm)
        {
            List<List<int>> newmatrix = new List<List<int>>();
            for (int i = 0; i < matrix[0].Count; ++i)
            {
                if (i == im) continue;
                newmatrix.Add(new List<int>());
                for (int j = 0; j < matrix[0].Count; ++j)
                {
                    if (j == jm) continue;
                    newmatrix.Last().Add(matrix[i][j]);
                }
            }
            return newmatrix;
        }
    }
}

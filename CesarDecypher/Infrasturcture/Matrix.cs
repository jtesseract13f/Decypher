using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarDecypher.Infrasturcture
{
    public static class Matrix
    {
        public static List<List<int>> Multiply(this List<List<int>> first, List<List<int>> second)
        {
            if (first[0].Count != second.Count)
            {
                throw new Exception("Умножение матриц невозможно: размеры матриц не совпадают");
            }
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < first.Count; ++i)
            {
                result.Add(new List<int>());
                for (int j = 0; j < second[0].Count; ++j)
                {
                    result[i].Add(0);
                    for (int k = 0; k < first[0].Count; ++k)
                    {
                        result[i][j] += first[i][k] * second[k][j];
                    }
                }
            }
            return result;
        }


        public static List<List<int>> Transpose(this List<List<int>> matrix)
        {
            var res = new List<List<int>>();

            for (int i = 0; i < matrix[0].Count; ++i)
            {
                res.Add(new List<int>());
                for (int j = 0; j < matrix.Count; ++j)
                {
                    res[i].Add(matrix[j][i]);
                }
            }

            return res;
        }
        public static List<List<int>> InverseModulo(this List<List<int>> matrix, int modulo)
        {
            var result = matrix.Incidence();
            var inverseDeterminant = matrix.Determinant(modulo).InverseModulo(modulo);
            for (int i = 0; i < matrix.Count; ++i)
            {
                for (int j = 0; j < matrix.Count; ++j)
                {
                    result[i][j] *= inverseDeterminant;
                    result[i][j] = result[i][j].ToPositive(modulo);
                }
            }
            return result;
        }

        public static List<List<int>> Incidence(this List<List<int>> matrix)
        {
            var result = new List<List<int>>();
            for (int j = 0; j < matrix[0].Count; ++j)
            {
                result.Add(new List<int>());
                for (int i = 0; i < matrix.Count; ++i)
                {
                    var sign = (i+j) % 2 == 0 ? 1 : -1;
                    result[j].Add(matrix.Cut(i, j).Determinant()*sign);
                }
            }
            return result;
        }
        public static int Determinant(this List<List<int>> matrix, int modulo)
        {
            if (matrix.Count != matrix[0].Count) { throw new Exception("Матрица не является квадратной"); }

            //var alp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя !,.".ToArray();

            if (matrix.Count == 1) return matrix[0][0];

            var det = 0;

            for (int i = 0; i < matrix.Count; ++i)
            {
                var sign = i % 2 == 0 ? 1 : -1;
                det += (Determinant(matrix.Cut(i, 0), modulo) * matrix[i][0] * sign).ToPositive(modulo);
            }
            return det;
        }
        public static List<List<int>> Cut(this List<List<int>> matrix, int row, int column)
        {
            var result = new List<List<int>>();

            for (int i = 0; i < matrix.Count; ++i)
            {
                if (i == row) continue;
                result.Add(new List<int>());
                for (int j = 0; j < matrix[i].Count; ++j)
                {
                    if (j == column) continue;
                    result.Last().Add(matrix[i][j]);
                }
            }
            return result;
        }

        public static void RandomizeMatrix(this List<List<int>> matrix)
        {
            var rand = new Random();
            for (int i = 0; i < matrix[0].Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    matrix[i][j] = rand.Next();
                }
            }
        }

        public static string MatrixToString(this List<List<int>> matrix)
        {
            StringBuilder result = new StringBuilder("");
            foreach (var row in matrix)
            {
                result.Append(';');
                foreach (var element in row)
                {
                    result.Append(element.ToString());
                    result.Append(' ');
                }
                result.Remove(result.Length - 1, 1);
            }
            result.Remove(0, 1);

            return result.ToString();
        }
    }
}

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
        Alphabet alphabet;
        int length;
        List<Tuple<List<int>, List<int>>> pairs;

        List<List<List<int>>> sourceMatrixList = new List<List<List<int>>>();
        List<List<List<int>>> encryptedMatrixList = new List<List<List<int>>>();

        public HillHacker(char[] _alphabet, List<Tuple<string, string>> _stringPairs, int _length)
        {
            alphabet = new Alphabet(_alphabet);
            length = _length;
            pairs = new List<Tuple<List<int>, List<int>>>();

            for (int i = 0; i < _stringPairs.Count; i++) {
                _stringPairs[i].Deconstruct(out var source, out var encrypted);
                if (source.Length < length)
                {
                    throw new Exception($"Размеры частей текста исходного и зашифрованного сообщения не совпадают:\n {source}\n{encrypted}\nНеобходимая длина:{length}");
                }
                pairs.Add(new Tuple<List<int>, List<int>>(alphabet.ToInt(source), alphabet.ToInt(encrypted)));
            }
        }
        public string TryGetkey()
        {
            return GetValidKey().MatrixToString();
        }
        public List<List<int>> GetValidKey()
        {
            FindValidCombinations(0, new List<List<int>>(), new List<List<int>>());
            var Y = encryptedMatrixList.FirstOrDefault();
            var X = sourceMatrixList.FirstOrDefault();

            if (Y == null || X == null)
            {
                throw new Exception("Ключ не найден");
            }
            var k = Y.Multiply(Y.InverseModulo(alphabet.Size));
            var key = Y.Transpose().Multiply(X.InverseModulo(alphabet.Size).Transpose());
            for (int i = 0; i < key.Count; ++i)
            {
                for (int j = 0; j < key[i].Count; ++j)
                {
                    key[i][j] = key[i][j].ToPositive(alphabet.Size);
                }
            }
            return key;
        }
        public void FindValidCombinations(int start, List<List<int>> sourceMatrix, List<List<int>> encryptedMatrix)
        {
            if (sourceMatrix.Count == length)
            {
                try
                {
                    sourceMatrix.InverseModulo(alphabet.Size);
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return;
                }
                sourceMatrixList.Add(sourceMatrix.Select(x => x.Select(y => y).ToList()).ToList());
                encryptedMatrixList.Add(encryptedMatrix.Select(x => x.Select(y => y).ToList()).ToList());
                return;
            }

            for (int i = start; i < pairs.Count; i++)
            {
                sourceMatrix.Add(pairs[i].Item1);
                encryptedMatrix.Add(pairs[i].Item2);
                FindValidCombinations(i + 1, sourceMatrix, encryptedMatrix);
                sourceMatrix.RemoveAt(sourceMatrix.Count - 1);
                encryptedMatrix.RemoveAt(encryptedMatrix.Count - 1);
            }
        }
    }
}

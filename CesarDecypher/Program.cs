using CesarDecypher.Infrasturcture;
using CesarDecypher.Services.Cyphers;
using CesarDecypher.Services.KeyHackers;
using CesarDecypher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CesarDecypher
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var mat = Matrix.Multiply(
                new List<List<int>>
                {
                        new List<int>{5, 3},
                        new List<int>{4, 1}
                },
                new List<List<int>>
                {
                        new List<int>{1, 0},
                        new List<int>{0, 1}
                }
                );
            var Hill = new Hill("abcdefghijklmnopqrstuvwxyz".ToCharArray(), "3,3;2,5");
            var encryptedMessage = Hill.Encrypt("help");
            var decryptedMessage = Hill.Decrypt(encryptedMessage);

            var pairs = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("he", "hi"),
                new Tuple<string, string>("lp", "at"),
                };
            var hacker = new HillHacker("abcdefghijklmnopqrstuvwxyz".ToCharArray(), pairs, 2);
            var key = hacker.TryGetkey();
            Hill._key = Hill.ParseKey(key);
            var decrypted = Hill.Decrypt(encryptedMessage);

            
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new KeyGenForm());
            }
            catch
            {

            }

        }
    }
}

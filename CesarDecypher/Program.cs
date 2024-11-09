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
            var Hill = new Hill("абвгдеёжзийклмнопрстуфхцчшщъыьэюя !,?".ToCharArray(), "3,3;2,5");
            var encryptedMessage = Hill.Encrypt("утро встало негры пашут сука");
            var decryptedMessage = Hill.Decrypt(encryptedMessage);

            
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch
            {

            }

        }
    }
}

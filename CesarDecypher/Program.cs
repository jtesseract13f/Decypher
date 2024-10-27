using CesarDecypher.Infrasturcture;
using CesarDecypher.Services.Cyphers;
using CesarDecypher.Services.KeyHackers;
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
                var Hill = new Hill("abcdefghijklmnopqrstuvwxyz. !".ToCharArray(), "6 24 1 2 7;13 16 10 13 1;18 2 23 15 7;9 24 11 16 21;20 7 22 3 17");
                var encryptedMessage = Hill.Encrypt("helomotherfuckerdestroydestroy");
                var decryptedMessage = Hill.Decrypt(encryptedMessage);
                
                var hacker = new HillHacker("abcdefghijklmnopqrstuvwxyz. !".ToCharArray(), "helomotherfuckerdestroydes", encryptedMessage, 5);
                var key = hacker.TryGetkey();
            Hill._key = Hill.ParseKey(key);
            var decrypted = Hill.Decrypt(encryptedMessage);

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
